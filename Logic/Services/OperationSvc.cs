using AutoMapper;
using DAL.Interfaces;
using Logic.Interfaces;
using Model.Models;

namespace Logic
{
    public class OperationSvc : IOperationSvc
    {
        private readonly IMapper _mapper;
        private readonly IOperationRepository _operationRepo;
        private readonly IImageRepository _imageRepo;
        private readonly int _rewardLimit = 10;

        public OperationSvc(
            IMapper mapper,
            IImageRepository imageRepository,
            IOperationRepository OperationRepository)
        {
            _imageRepo = imageRepository;
            _operationRepo = OperationRepository;
            _mapper = mapper;
        }

        public int GetUserBalance(int userId)
            => _operationRepo.GetUserOperations(userId).Sum(x => x.Amount);
        public IEnumerable<OperationDTO> GetUserOperations(int userId)
            => _mapper.Map<IEnumerable<OperationDTO>>(_operationRepo.GetUserOperations(userId));
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

                _operationRepo.TipImage(tip.UserId, tip.ImageId, authorId, tip.Amount);
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
                var lastReward = _operationRepo.GetWhere(x => x.UserId == userId && x.OperationId == 3).OrderByDescending(x=>x.OperationDate).FirstOrDefault()?.OperationDate;

                if (lastReward == null || lastReward <= DateTime.Now.AddDays(-1))
                {
                    var amount = _operationRepo.GetOperationValue(3);
                    _operationRepo.Add(new(userId, 3, amount));
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
            var amount = _operationRepo.GetOperationValue(2);
            var operations = _operationRepo.GetWhere(x => x.UserId == userId || x.UserId == authorId).ToList();
            var userOp = operations.Where(x => x.UserId == userId);
            var authorOp = operations.Where(x => x.UserId == authorId);
            if (userOp.Count(x => x.OperationId == 2 && x.OperationDate.Value.Date == DateTime.Today) < _rewardLimit)
            {
                _operationRepo.Add(new(userId, 2, amount));
            }
            if (authorOp.Count(x => x.OperationId == 7 && x.OperationDate.Value.Date == DateTime.Today) < _rewardLimit)
            {
                _operationRepo.Add(new(authorId, 7, amount));
            }
        }
        public int GenerationFee(MetadataDTO metadata, int userId)
        {
            var balance = GetUserBalance(userId);
            var fee = CalculateGenerationFee(metadata);

            if (fee > balance)
                return -1;
            
            _operationRepo.Add(new(userId,5,-fee));
            return 0;
        }
        public int AwardPostingReward(int userId)
        {
            var amount = _operationRepo.GetOperationValue(4);
            var operations = _operationRepo.GetWhere(x => x.UserId == userId && x.OperationId == 4).ToList();

            if (!operations.Any(x => x.OperationDate.Value.Date == DateTime.Today))
            {
                _operationRepo.Add(new(userId, 4, amount));
                return 0;
            }
            return -1;
        }
        private int CalculateGenerationFee(MetadataDTO metadata) 
        {
            var baseFee = 5;
            var loraFee = ((metadata.Lora1Id == null ? 0 : 1) + (metadata.Lora2Id == null ? 0 : 1)) * 3;
            var stepsFee = ((metadata.Steps - Math.Min(metadata.Steps,20))/5)*2;

            return baseFee+loraFee+stepsFee;
        }


    }
}
