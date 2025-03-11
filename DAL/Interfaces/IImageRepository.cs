namespace DAL.Interfaces
{
    public interface IImageRepository : IGenericRepository<Image>
    {
        public IEnumerable<Image> GetUserImages(int userId);
        public IEnumerable<Image> GetCheckpointImages(int modelId);
        public IEnumerable<Image> GetLoraImages(int modelId);
        public IEnumerable<Image> GetCollectionImages(int collectionId);
        public Metadata GetImageMetadata(int imageId);
        public Image GetImageData(int imageId);
        public void PostReaction(Reaction reaction);
        public void PostComment(Comment comment);
        public IEnumerable<Comment> GetComments(int imageId);
        public int SaveMetadata(Metadata metadata);
        public void DeleteImage(Guid imageRef);
    }
}
