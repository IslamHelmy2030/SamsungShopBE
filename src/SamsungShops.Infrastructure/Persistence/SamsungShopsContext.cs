using Microsoft.EntityFrameworkCore;
using SamsungShops.Domain.Common;
using SamsungShops.Domain.Entities;

namespace SamsungShops.Infrastructure.Persistence
{
    public partial class SamsungShopsContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<HotDeal> HotDeals { get; set; }
        public DbSet<HomePageSlider> HomePageSliders { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
