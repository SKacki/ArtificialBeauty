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
        private readonly IImageRepository _imageRepo;
        private readonly int _rewardLimit = 10;

        public OperationSvc(
            IMapper mapper,
            IImageRepository imageRepository,
            IOperationRepository OperationRepository)
        {
            _imageRepo = imageRepository;
            _OperationRepo = OperationRepository;
            _mapper = mapper;
        }

        public IEnumerable<OperationDTO> GetUserOperations(int userId)
            => _mapper.Map<IEnumerable<OperationDTO>>(_OperationRepo.GetUserOperations(userId));
        public int TipImage(TipDTO tip)
        {
            try
            {
                var authorId = _imageRepo.GetImageData(tip.ImageId).UserId;
                var balance = GetUserOperations(tip.UserId).Sum(x => x.Amount);
                if (authorId == tip.UserId)
                    return -1;
                if (balance < tip.Amount) 
                    return -2;  

                _OperationRepo.TipImage(tip.UserId, tip.ImageId, authorId, tip.Amount);
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong");
            }
        }

        public int ClaimDailyReward(int userId)
        {
            try
            {
                var status = 1;
                var lastReward = _OperationRepo.GetWhere(x => x.UserId == userId && x.OperationId == 3).SingleOrDefault()?.OperationDate;

                if (lastReward == null || lastReward <= DateTime.Now.AddDays(-1))
                {
                    var amount = _OperationRepo.GetOperationValue(3);
                    _OperationRepo.Add(new(userId, 3, amount));
                    return status;
                }
                else { return 0; }
            }
            catch (Exception ex) 
            {
                throw new Exception("Something went wrong here");
            }
        
        }

        public void GiveInteractionRewards(int userId, int authorId)
        {
            var amount = _OperationRepo.GetOperationValue(2);
            var operations = _OperationRepo.GetWhere(x => x.UserId == userId || x.UserId == authorId).ToList();
            var userOp = operations.Where(x => x.UserId == userId);
            var authorOp = operations.Where(x => x.UserId == authorId);
            if (userOp.Count(x => x.OperationId == 2 && x.OperationDate.Value.Date == DateTime.Today) < _rewardLimit)
            {
                _OperationRepo.Add(new(userId, 2, amount));
            }
            if (authorOp.Count(x => x.OperationId == 7 && x.OperationDate.Value.Date == DateTime.Today) < _rewardLimit)
            {
                _OperationRepo.Add(new(authorId, 7, amount));
            }
        }
    }
}
