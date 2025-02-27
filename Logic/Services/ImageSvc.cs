using AutoMapper;
using DAL.Interfaces;
using Logic.Interfaces;
using Model.Models;

namespace Logic
{
    public class ImageSvc : IImageSvc
    {
        private readonly IMapper _mapper;
        private readonly IImageRepository _imageRepo;
        private readonly IModelSvc _modelSvc;

        public ImageSvc(
            IMapper mapper,
            IImageRepository imageRepository,
            IModelSvc modelSvc)
        {
            _imageRepo = imageRepository;
            _modelSvc = modelSvc;
            _mapper = mapper;
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
                            .Take(5);
            return _mapper.Map<IEnumerable<ImageDTO>>(images);
        }
    }
}
