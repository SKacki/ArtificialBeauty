using Model.Models;

namespace Logic.Interfaces
{
    public interface IOperationSvc
    {
        public IEnumerable<OperationDTO> GetUserOperations(int userId);
        public int TipImage(TipDTO tip);
        public int ClaimDailyReward(int userId);
        public void GiveInteractionRewards(int userId, int authorId);
    }
}
