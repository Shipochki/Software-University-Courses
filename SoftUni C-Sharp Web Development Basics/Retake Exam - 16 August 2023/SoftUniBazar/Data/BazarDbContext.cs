using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data.Models;

namespace SoftUniBazar.Data
{
    public class BazarDbContext : IdentityDbContext
    {
        public BazarDbContext(DbContextOptions<BazarDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Category>()
                .HasData(new Category()
                {
                    Id = 1,
                    Name = "Books"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Cars"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Clothes"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Home"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Technology"
                });

            modelBuilder.Entity<AdBuyer>()
                .HasKey(a => new { a.BuyerId, a.AdId });

            modelBuilder.Entity<AdBuyer>()
                .HasOne(a => a.Ad)
                .WithMany()
                .HasForeignKey(a => a.AdId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AdBuyer>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.BuyerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ad>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Ad> Ads { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

		public DbSet<AdBuyer> AdsBuyers { get; set; }
	}
}