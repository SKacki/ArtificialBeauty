using Model.Models;

namespace Logic.Interfaces
{
    public interface IImageSvc
    {
        public IEnumerable<ImageDTO> GetCheckpointImages(int modelId);
        public IEnumerable<ImageDTO> GetUserImages(int userId);
        public IEnumerable<ImageDTO> GetModelImages(int modelId);
        public MetadataDTO GetImageMetadata(int imageId);
        public ImageDTO GetImageData(int imageId);
        public IEnumerable<ImageDTO> GetFeaturedImages();
        public byte[] GetImage(Guid imageId);
        public byte[] GetImage(int imageId);
        public void PostReaction(int imageId, int userId, int type);
        public void PostComment(int imageId, int userId, string comment);
    }
}
