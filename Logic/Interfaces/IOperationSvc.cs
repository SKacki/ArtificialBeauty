using Model.Models;

namespace Logic.Interfaces
{
    public interface IOperationSvc
    {
        public int GetUserBalance(int userId);
        public IEnumerable<OperationDTO> GetUserOperations(int userId);
        public int TipImage(TipDTO tip);
        public int ClaimDailyReward(int userId);
        public void GiveInteractionRewards(int userId, int authorId);
        public int GenerationFee(MetadataDTO metadata, int userId);
        public int AwardPostingReward(int userId);
    }
}
