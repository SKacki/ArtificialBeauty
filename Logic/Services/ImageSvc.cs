using AutoMapper;
using DAL.Interfaces;
using Logic.Configs;
using Logic.Interfaces;
using Microsoft.Extensions.Options;
using Model.Models;
using DAL;
using static System.Net.Mime.MediaTypeNames;

namespace Logic
{
    public class ImageSvc : IImageSvc
    {
        private readonly IMapper _mapper;
        private readonly IImageRepository _imageRepo;
        private readonly IModelRepository _modelRepo;
        private readonly IModelSvc _modelSvc;
        private readonly IOperationSvc _operationSvc;
        private readonly string _repoPath;

        public ImageSvc(
            IMapper mapper,
            IImageRepository imageRepository,
            IModelRepository modelRepository,
            IModelSvc modelSvc,
            IOperationSvc operationSvc,
            IOptions<ImageRepositorySettings> options)
        {
            _imageRepo = imageRepository;
            _modelRepo = modelRepository;
            _modelSvc = modelSvc;
            _operationSvc = operationSvc;
            _mapper = mapper;
            _repoPath = options.Value.Path;
        }

        public IEnumerable<ImageDTO> GetCheckpointImages(int modelId)
            => _mapper.Map<IEnumerable<ImageDTO>>(_imageRepo.GetCheckpointImages(modelId));
        public IEnumerable<ImageDTO> GetLoraImages(int modelId)
            => _mapper.Map<IEnumerable<ImageDTO>>(_imageRepo.GetLoraImages(modelId));
        public IEnumerable<ImageDTO> GetUserImages(int userId)
            => _mapper.Map<IEnumerable<ImageDTO>>(_imageRepo.GetUserImages(userId));
        public IEnumerable<ImageDTO> GetModelImages(int modelId)
        {
            var modelType = _modelSvc.GetById(modelId)?.Type;

            if (modelType == "Checkpoint")
            {
                return GetCheckpointImages(modelId);
            }
            else 
            {
                return GetLoraImages(modelId);
            }
        }
        public ImageDTO GetImageData(int imageId)
            => _mapper.Map<ImageDTO>(_imageRepo.GetImageData(imageId));
        public MetadataDTO GetImageMetadata(int imageId) 
            => _mapper.Map<MetadataDTO>(_imageRepo.GetImageMetadata(imageId));

        public IEnumerable<ImageDTO> GetFeaturedImages()
        {
            var images = _imageRepo.GetAllAsIEnumerable()
                            .Where(x => x.UploadDate != null)
                            .OrderByDescending(x => x.UploadDate)
                            .Take(10);
            return _mapper.Map<IEnumerable<ImageDTO>>(images);
        }

        public IEnumerable<ImageDTO> SearchImages(string searchTerm) 
            => _mapper.Map<IEnumerable<ImageDTO>>(_imageRepo.GetWhere(x => x.Description.Contains(searchTerm)));
   
        public IEnumerable<ImageDTO> GetAllImages()
            => _mapper.Map<IEnumerable<ImageDTO>>(_imageRepo.GetAllAsIEnumerable());

        public IEnumerable<ImageDTO> GetFeaturedModels(IEnumerable<int>?ids)
        {
            var images = _imageRepo.GetAllAsIEnumerable()
                            .Where(x => ids.Contains(x.Id))
                            .OrderByDescending(x => x.UploadDate)
                            .Take(20);

            var models = _modelRepo.GetAllAsIEnumerable().ToList();

            foreach (var item in images)
            {
                var model = models.FirstOrDefault(x => x.ID == item.ExampleOfModel.ModelId);
                item.Description = $"[{model.Type}] {model.ModelName}";
                item.User = model.Publisher;
                item.UserId = (int)model.PublisherId; 
            }

            return _mapper.Map<IEnumerable<ImageDTO>>(images);
        }

        public byte[] GetImage(Guid imageId)
        {
            var imagePath = Path.Combine(_repoPath, string.Concat(imageId.ToString(), ".png"));

            if (!File.Exists(imagePath))
            {
                throw new Exception("Image not found");
            }
            return File.ReadAllBytes(imagePath);
        }
        public byte[] GetImage(int imageId)
        {
            var imageRef = _imageRepo.GetById(imageId).Ref;
            var imagePath = Path.Combine(_repoPath, string.Concat(imageRef.ToString(), ".png"));

            if (!File.Exists(imagePath))
            {
                throw new Exception("Image not found");
            }
            return File.ReadAllBytes(imagePath);
        }

        public int PostReaction(ReactionDTO reaction)
        {
            try
            {
                var image = _imageRepo.GetWhere(x => x.Id == reaction.ImageId).SingleOrDefault();
                if (image.UserId == reaction.UserId)
                    return -1;
                
                if (image.Reactions.Any(x => x.UserId == reaction.UserId)) 
                    return -2;
                
                _imageRepo.PostReaction(_mapper.Map<Reaction>(reaction));
                _operationSvc.GiveInteractionRewards(reaction.UserId, image.UserId);
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong here");
            }
        }
        public void PostComment(CommentDTO comment)
        {
            _imageRepo.PostComment(_mapper.Map<Comment>(comment));
        }
        public IEnumerable<CommentDTO> GetComments(int imageId)
            => _mapper.Map<IEnumerable<CommentDTO>>(_imageRepo.GetComments(imageId));
    }
}
