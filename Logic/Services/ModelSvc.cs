using AutoMapper;
using DAL;
using DAL.Interfaces;
using Logic.Interfaces;
using Model.Models;
using model = DAL.Model;

namespace Logic
{
    public class ModelSvc : IModelSvc
    {

        private readonly IMapper _mapper;
        private readonly IModelRepository _modelRepo;

        public ModelSvc(
            IMapper mapper,
            IModelRepository modelRepository)
        {
            _modelRepo = modelRepository;
            _mapper = mapper;
        }


        public ModelDTO GetById(int modelId)
            => _mapper.Map<ModelDTO>(_modelRepo.GetById(modelId));
        public IEnumerable<ModelDTO> GetAll() =>
            _mapper.Map<IEnumerable<model>, IEnumerable<ModelDTO>>(_modelRepo.GetAllAsIEnumerable());
        public IEnumerable<ModelDTO> SearchByName(string searchTerm) =>
            _mapper.Map<IEnumerable<model>, IEnumerable<ModelDTO>>(_modelRepo.GetByName(searchTerm));
        public IEnumerable<ModelDTO> GetCheckpoints() =>
            _mapper.Map<IEnumerable<model>, IEnumerable<ModelDTO>>(_modelRepo.GetModels());
        public IEnumerable<ModelDTO> GetAdditionalResources() =>
            _mapper.Map<IEnumerable<model>, IEnumerable<ModelDTO>>(_modelRepo.GetAdditionalResources());

        public IEnumerable<ModelExample> GetModelExamples()
            => _modelRepo.GetExampleImages();
    }
}
