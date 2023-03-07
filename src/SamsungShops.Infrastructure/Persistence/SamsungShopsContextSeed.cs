using Microsoft.Extensions.Logging;
using SamsungShops.Domain.Entities;

namespace SamsungShops.Infrastructure.Persistence
{
    public class SamsungShopsContextSeed
    {
        public static async Task SeedAsync(SamsungShopsContext samsungShopsContext, ILogger<SamsungShopsContextSeed> logger)
        {
            if (!samsungShopsContext.Products.Any())
            {
                samsungShopsContext.Products.AddRange(GetPreconfiguredProducts());
                await samsungShopsContext.SaveChangesAsync();
                logger.LogInformation($"Seed database associated with context {nameof(SamsungShopsContext)}");
            }
        }
        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>
            {
                new Product() {
                    Name="Samsung As2",
                    Description="Samsung As2 128G",
                    Summary="Samsung As2",
                    CategoryName="Mobile",
                    CategoryId=1,
                    ImageFile="",
                    IsVisible=true,
                    Price=1000
                },
                new Product() {
                    Name="Refrigerator 12 Feet",
                    Description="Refrigerator 12 Feet",
                    Summary="Refrigerator 12 Feet 12",
                    CategoryName="Refrigerator",
                    CategoryId=2,
                    ImageFile="",
                    IsVisible=true,
                    Price=15000
                },
                new Product() {
                    Name="Microwave 180W",
                    Description="Microwave 180W 180 Width",
                    Summary="Microwave 1 Feet",
                    CategoryName="Microwave",
                    CategoryId=3,
                    ImageFile="",
                    IsVisible=true,
                    Price=1000
                },
            };
        }
    }
}
