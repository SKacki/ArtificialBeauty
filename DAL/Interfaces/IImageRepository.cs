namespace DAL.Interfaces
{
    public interface IImageRepository : IGenericRepository<Image>
    {
        public IEnumerable<Image> GetUserImages(int userId);
        public IEnumerable<Image> GetCheckpointImages(int modelId);
        public IEnumerable<Image> GetLoraImages(int modelId);
        public IEnumerable<Image> GetCollectionImages(int collectionId);
    }
}
