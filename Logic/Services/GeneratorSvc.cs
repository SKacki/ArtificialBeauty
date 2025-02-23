using AutoMapper;
using DAL.Interfaces;
using Logic.Interfaces;
using Model.Models;
using System.ComponentModel.DataAnnotations;
using model = DAL.Model;

namespace Logic
{
    public class GeneratorSvc : IGeneratorSvc
    {

        private readonly IMapper _mapper;
        private readonly IUserSvc _userSvc;
        private readonly IModelRepository _modelRepo;
        private readonly GeneratorClient _client;
        private readonly MetadataValidator _validator;

        public GeneratorSvc(
            IMapper mapper,
            IUserSvc userSvc,
            IModelRepository modelRepository,
            GeneratorClient genClient)
        {
            _userSvc = userSvc;
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
    }
}
