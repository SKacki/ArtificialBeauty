using DAL.Interfaces;

namespace DAL.Repos
{
    public  class AuthRepository(AuthDbContext context) : IAuthRepository
    {
        protected readonly AuthDbContext _context = context;

        public string GetUID(string email) 
            => _context.Users.FirstOrDefault(u => u.Email == email).Id;
    }
}
