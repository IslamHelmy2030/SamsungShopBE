using SamsungShops.Domain.Common;

namespace SamsungShops.Domain.Entities
{
    public class Category : EntityBase
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsVisible { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
