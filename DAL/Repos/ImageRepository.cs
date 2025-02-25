using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repos
{
    public class ImageRepository : GenericRepository<Image>, IImageRepository
    {
        public ImageRepository(AppDbContext context) : base(context) { }
        public IEnumerable<Image> GetCheckpointImages(int modelId)
            => GetAll().Where(x=>x.Metadata.ModelId == modelId && x.UploadDate != null);
            
        public IEnumerable<Image> GetLoraImages(int modelId)
            => GetAll().Where(x => (x.Metadata.Lora1Id == modelId || x.Metadata.Lora2Id == modelId) && x.UploadDate != null);
        public IEnumerable<Image> GetUserImages(int userId)
            => GetAll().Where(x => x.UserId == userId && x.UploadDate != null);
        public IEnumerable<Image> GetCollectionImages(int collectionId)
            => Context.ImagesCollections.Include(x => x.Image)
                .ThenInclude(x => x.Reactions).ThenInclude(x => x.Image.Tips).ThenInclude(x=>x.Image.Comments)
                .Where(x => x.CollectionId == collectionId).Select(x=>x.Image);
        public Metadata GetImageMetadata(int imageId) 
            => Context.Metadata.Include(m => m.Image).SingleOrDefault(x => x.Id == imageId);
        private IQueryable<Image> GetAll()
            => GetAllAsIQueryable().Include(x => x.Metadata).Include(x => x.Reactions).Include(x => x.Tips).Include(x => x.Comments);

    }
}