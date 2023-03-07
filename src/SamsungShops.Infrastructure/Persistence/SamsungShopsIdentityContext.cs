using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SamsungShops.Domain.Entities;
using SamsungShops.Domain.IdentityEntities;

namespace SamsungShops.Infrastructure.Persistence
{
    public partial class SamsungShopsContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private readonly IDataInitializer _dataInitializer;

        public SamsungShopsContext(DbContextOptions<SamsungShopsContext> options, IDataInitializer dataInitializer) : base(options) => _dataInitializer = dataInitializer;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.Property(x => x.FirstName).HasMaxLength(50);
                b.Property(x => x.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<ApplicationRole>(b =>
            {
                b.HasData(_dataInitializer.GetInitialRoles());
            });

            modelBuilder.Entity<Category>(b =>
            {
                b.ToTable(nameof(Category));
                b.Property(p => p.Name).HasMaxLength(50);
                b.Property(p => p.Description).HasMaxLength(500);
                b.Property(p => p.CreatedBy).HasMaxLength(50);
                b.Property(p => p.LastModifiedBy).HasMaxLength(50);
                b.HasData(new List<Category> {
                new Category() {Id = 1, Name = "Mobile", Description = "Mobile Category", IsVisible = true },
                new Category() {Id = 2, Name = "Refrigerator", Description = "Mobile Category", IsVisible = true },
                new Category() {Id = 3, Name = "Microwave", Description = "Microwave Category", IsVisible = true }
                });
            });

            modelBuilder.Entity<Product>(b =>
            {
                b.ToTable(nameof(Product));
                b.Property(p => p.Name).HasMaxLength(50);
                b.Property(p => p.Summary).HasMaxLength(200);
                b.Property(p => p.Description).HasMaxLength(500);
                b.Property(p => p.ImageFile).HasMaxLength(200);
                b.Property(p => p.Price).HasDefaultValue(0);
                b.Property(p => p.CategoryName).HasMaxLength(50);
                b.Property(p => p.CreatedBy).HasMaxLength(50);
                b.Property(p => p.LastModifiedBy).HasMaxLength(50);

                b.HasOne(p => p.Category).WithMany(p => p.Products).HasForeignKey(p => p.CategoryId);
            });

            modelBuilder.Entity<Image>(b =>
            {
                b.ToTable(nameof(Image));
                b.Property(p => p.Name).HasMaxLength(50);
                b.Property(p => p.Description).HasMaxLength(500);
                b.Property(p => p.ImageFile).HasMaxLength(200);
                b.Property(p => p.ProductName).HasMaxLength(50);
                b.Property(p => p.CreatedBy).HasMaxLength(50);
                b.Property(p => p.LastModifiedBy).HasMaxLength(50);

                b.HasOne(p => p.Product).WithMany(p => p.Images).HasForeignKey(p => p.ProductId);
            });

            modelBuilder.Entity<Discount>(b =>
            {
                b.ToTable(nameof(Discount));
                b.Property(p => p.Name).HasMaxLength(50);
                b.Property(p => p.Description).HasMaxLength(500);
                b.Property(p => p.Amount).HasDefaultValue(0);
                b.Property(p => p.IsExpired).HasDefaultValue(false);
                b.Property(p => p.ProductName).HasMaxLength(50);
                b.Property(p => p.CreatedBy).HasMaxLength(50);
                b.Property(p => p.LastModifiedBy).HasMaxLength(50);

                b.HasOne(p => p.Product).WithMany(p => p.Discounts).HasForeignKey(p => p.ProductId);
            });

            modelBuilder.Entity<HotDeal>(b =>
            {
                b.ToTable(nameof(HotDeal));
                b.Property(p => p.ProductName).HasMaxLength(50);
                b.Property(p => p.ImageFile).HasMaxLength(200);
                b.Property(p => p.Price).HasDefaultValue(0);
                b.Property(p => p.Discount).HasDefaultValue(0);
                b.Property(p => p.CreatedBy).HasMaxLength(50);
                b.Property(p => p.LastModifiedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<HomePageSlider>(b =>
            {
                b.ToTable(nameof(HomePageSlider));
                b.Property(p => p.ProductName).HasMaxLength(50);
                b.Property(p => p.ImageFile).HasMaxLength(200);
                b.Property(p => p.Summary).HasMaxLength(200);
                b.Property(p => p.Description).HasMaxLength(500);
                b.Property(p => p.CreatedBy).HasMaxLength(50);
                b.Property(p => p.LastModifiedBy).HasMaxLength(50);
            });



            base.OnModelCreating(modelBuilder);
        }

    }
}
