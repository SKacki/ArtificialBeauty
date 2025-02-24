using AutoMapper;
using DAL.Interfaces;
using Logic.Interfaces;
using Model.Models;

namespace Logic
{
    public class OperationSvc : IOperationSvc
    {
        private readonly IMapper _mapper;
        private readonly IOperationRepository _OperationRepo;

        public OperationSvc(
            IMapper mapper,
            IOperationRepository OperationRepository)
        {
            _OperationRepo = OperationRepository;
            _mapper = mapper;
        }

        public IEnumerable<OperationDTO> GetUserOperations(int userId)
            => _mapper.Map<IEnumerable<OperationDTO>>(_OperationRepo.GetUserOperations(userId));
    }
}
