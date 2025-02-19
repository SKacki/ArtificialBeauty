using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ImagesCollection> ImagesCollections { get; set; }
        public DbSet<Metadata> Metadata { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationsHistory> OperationsHistory { get; set; }
        public DbSet<ProfilePicture> ProfilePictures { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Follower>()
                .HasOne(o => o.UserFollower)
                .WithMany(u => u.Followers)
                .HasForeignKey(o => o.FollowerId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Follower>()
                .HasOne(o => o.UserFollowing)
                .WithMany(u => u.Following)
                .HasForeignKey(o => o.FollowingId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Metadata>()
                .HasOne(o => o.Model)
                .WithMany(u => u.ModelMetadata)
                .HasForeignKey(o => o.ModelId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Metadata>()
                .HasOne(o => o.Lora1)
                .WithMany(u => u.Lora1Metadata)
                .HasForeignKey(o => o.Lora1Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Metadata>()
                .HasOne(o => o.Lora2)
                .WithMany(u => u.Lora2Metadata)
                .HasForeignKey(o => o.Lora2Id)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}