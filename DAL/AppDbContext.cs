using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        //public DbSet<Uzytkownik> Uprawnienia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Ocena>()
            //    .HasOne(o => o.ZatwiedzajacyOcene)
            //    .WithMany(z => z.ZatwierdzoneOceny)
            //    .HasForeignKey(o => o.ZatwierdzajacyOceneId)
            //    .IsRequired(false);
        }
    }
}