namespace DAL.Interfaces
{
    public interface IModelRepository : IGenericRepository<Model>
    {
        public IEnumerable<Model> GetByName(string searchTerm);
        public IEnumerable<Model> GetModels();
        public IEnumerable<Model> GetAdditionalResources();
        public IEnumerable<ModelExample> GetExampleImages();
    }
}
