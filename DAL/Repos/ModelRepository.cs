using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace DAL.Repos
{
    public class ModelRepository : GenericRepository<Model>, IModelRepository
    {
        public ModelRepository(AppDbContext context) : base(context){}

        public override Model GetById(int id)
            => _table.Include(x=>x.Publisher).Where(x=>x.ID == id).FirstOrDefault();
        public override IEnumerable<Model> GetAllAsIEnumerable()
            => _table.Include(x => x.Publisher);
        public IEnumerable<Model> GetByName(string searchTerm) => 
            base.GetAllAsIQueryable().Where(x => x.ModelName.Contains(searchTerm)).AsEnumerable();
        public IEnumerable<Model> GetModels() =>
            base.GetAllAsIQueryable().Where(x => x.Type == "Checkpoint").AsEnumerable();
        public IEnumerable<Model> GetAdditionalResources() =>
            base.GetAllAsIQueryable().Where(x => x.Type != "Checkpoint").AsEnumerable();
        public IEnumerable<ModelExample> GetExampleImages() =>
            Context.ModelExamples.Include(x=>x.Image)
            .ThenInclude(x=>x.Reactions)
            .GroupBy(x=>x.ModelId)
            .Select(x=>x.OrderByDescending(x=>x.Image.Reactions.Count(x=>x.Type == 1))
            .FirstOrDefault());      
    }
}