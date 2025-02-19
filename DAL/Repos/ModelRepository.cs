using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repos
{
    public class ModelRepository : GenericRepository<Model>,  IModelRepository
    {
        public ModelRepository(AppDbContext context) : base(context)
        {
        }        
    }
}