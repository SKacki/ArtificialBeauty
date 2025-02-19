using AutoMapper;
using DAL;
using DAL.Interfaces;
using Logic.Interfaces;
using Model.Models;

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

        public IEnumerable<ModelDTO> GetAllModels() =>
            _mapper.Map<IEnumerable<DAL.Model>,IEnumerable<ModelDTO>>(_modelRepo.GetAllAsIEnumerable());
    }
}
