using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
            => Context.Metadata
                .Include(x => x.Model)
                .Include(x => x.Lora1)
                .Include(x => x.Lora2)
                .Include(m => m.Image)
                .SingleOrDefault(x => x.Image.Id == imageId);
        public Image GetImageData(int imageId) 
            => GetAll().SingleOrDefault(x => x.Id == imageId);
        public override IEnumerable<Image> GetAllAsIEnumerable() 
            => GetAll().AsEnumerable();
        public override IEnumerable<Image> GetWhere(Expression<Func<Image, bool>> predicate)
            => GetAll().Where(predicate);

        public void PostReaction(Reaction reaction)
        {
            Context.Reactions.Add(reaction);
            base.SaveChanges();
        }

        public void PostComment(Comment comment)
        {
            Context.Comments.Add(comment);
            base.SaveChanges();
        }

        private IQueryable<Image> GetAll()
            => GetAllAsIQueryable()
                .Include(x=>x.User)
                .Include(x=>x.ExampleOfModel)
                .Include(x => x.Comments).ThenInclude(x => x.User)
                .Include(x => x.Reactions)
                .Include(x => x.Tips).ThenInclude(x=>x.Operation);

        public IEnumerable<Comment> GetComments(int imageId)
            => Context.Comments.Include(x=>x.User).Where(x=>x.ImageId == imageId);

        public int SaveMetadata(Metadata metadata)
        {
            Context.Metadata.Add(metadata);
            base.SaveChanges();
            return metadata.Id;
        }
    }
}