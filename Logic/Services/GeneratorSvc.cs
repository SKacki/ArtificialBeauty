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
        private readonly MetadataValidator _validator;

        public GeneratorSvc(
            IMapper mapper,
            IUserSvc userSvc,
            IImageSvc imageSvc,
            IModelRepository modelRepository,
            GeneratorClient genClient)
        {
            _userSvc = userSvc;
            _imageSvc = imageSvc;
            _modelRepo = modelRepository;
            _mapper = mapper;
            _client = genClient;
            _validator = new MetadataValidator();
        }

        public void RequestGeneration(MetadataDTO metadata)
        {
            if (_validator.Validate(metadata).IsValid)
            {
                var result = _client.PostAsync<MetadataDTO>("endpoint", metadata);
            }
        }
        public MetadataDTO RemixImage(int metadataId) => _imageSvc.GetImageMetadata(metadataId);

    }
}
