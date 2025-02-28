using AutoMapper;
using DAL.Interfaces;
using Logic.Configs;
using Logic.Interfaces;
using Microsoft.Extensions.Options;
using Model.Models;

namespace Logic
{
    public class ImageSvc : IImageSvc
    {
        private readonly IMapper _mapper;
        private readonly IImageRepository _imageRepo;
        private readonly IModelSvc _modelSvc;
        private readonly IOperationSvc _operationSvc;
        private readonly string _repoPath;

        public ImageSvc(
            IMapper mapper,
            IImageRepository imageRepository,
            IModelSvc modelSvc,
            IOperationSvc operationSvc,
            IOptions<ImageRepositorySettings> options)
        {
            _imageRepo = imageRepository;
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
        public ImageDTO GetImage(int imageId) 
            => _mapper.Map<ImageDTO>(_imageRepo.GetById(imageId));

        public IEnumerable<ImageDTO> GetFeaturedImages()
        {
            var images = _imageRepo.GetAllAsIEnumerable()
                            .Where(x => x.UploadDate != null)
                            .OrderByDescending(x => x.UploadDate)
                            .Take(10);
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

        public void PostReaction(int imageId, int userId, int type)
        {
            var image =_imageRepo.GetWhere(x => x.Id == imageId).SingleOrDefault();
            if (!image.Reactions.Any(x => x.UserId == userId) && image.UserId != userId)
            {
                _imageRepo.PostReaction(new(type,imageId,userId));
                _operationSvc.GiveInteractionRewards(userId, image.UserId);
            }
        }

        public void PostComment(int imageId, int userId, string comment)
        {
            _imageRepo.PostComment(new(imageId, userId, comment));
        }
    }
}
