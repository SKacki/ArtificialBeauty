using AutoMapper;
using DAL.Interfaces;
using Logic.Configs;
using Logic.Interfaces;
using Microsoft.Extensions.Options;
using Model.Models;

namespace Logic
{
    public class GeneratorSvc : IGeneratorSvc
    {

        private readonly IMapper _mapper;
        private readonly IUserSvc _userSvc;
        private readonly IImageSvc _imageSvc;
        private readonly IModelRepository _modelRepo;
        private readonly GeneratorClient _client;
        private readonly string _repoPath;
        private readonly MetadataValidator _validator;

        public GeneratorSvc(
            IMapper mapper,
            IUserSvc userSvc,
            IImageSvc imageSvc,
            IModelRepository modelRepository,
            GeneratorClient genClient,
            IOptions<ImageRepositorySettings> options)
        {
            _userSvc = userSvc;
            _imageSvc = imageSvc;
            _modelRepo = modelRepository;
            _mapper = mapper;
            _client = genClient;
            _validator = new MetadataValidator();
            _repoPath = options.Value.Path;
        }

        public void RequestGeneration(MetadataDTO metadata)
        {
            if (_validator.Validate(metadata).IsValid)
            {
                var result = _client.PostAsync<MetadataDTO>("endpoint", metadata);
            }
        }
        public MetadataDTO RemixImage(int metadataId) => _imageSvc.GetImageMetadata(metadataId);
        public byte[] GetImage(int imageId)
        {
            var img = _imageSvc.GetImage(imageId);
            var imagePath = Path.Combine(_repoPath, string.Concat(img.Ref.ToString(), ".png"));

            if (!File.Exists(imagePath))
            {
                throw new Exception("Image not found");
            }
            return File.ReadAllBytes(imagePath);
        }
    }
}
