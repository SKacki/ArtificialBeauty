using Model.Models;

namespace Logic.Interfaces
{
    public interface IOperationSvc
    {
        public IEnumerable<OperationDTO> GetUserOperations(int userId);
        public void TipImage(int imageId, int userId, int amount);
        public void ClaimDailyReward(int userId);
        public void GiveInteractionRewards(int userId, int authorId);
    }
}
