using DAL.Interfaces;


namespace DAL.Repos
{
    public class ModelRepository : GenericRepository<Model>, IModelRepository
    {
        public ModelRepository(AppDbContext context) : base(context){}

        public IEnumerable<Model> GetByName(string searchTerm) => 
            base.GetAllAsIQueryable().Where(x => x.ModelName.Contains(searchTerm)).AsEnumerable();
        public IEnumerable<Model> GetModels() =>
            base.GetAllAsIQueryable().Where(x => x.Type == "Checkpoint").AsEnumerable();
        public IEnumerable<Model> GetAdditionalResources() =>
            base.GetAllAsIQueryable().Where(x => x.Type != "Checkpoint").AsEnumerable();
    }
}