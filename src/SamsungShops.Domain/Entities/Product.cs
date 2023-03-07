using SamsungShops.Domain.Common;

namespace SamsungShops.Domain.Entities
{
    public class Product : EntityBase
    {
        public string? Name { get; set; }
        public string? Summary { get; set; }
        public string? Description { get; set; }
        public string? ImageFile { get; set; }
        public double Price { get; set; }
        public string? CategoryName { get; set; }
        public int CategoryId { get; set; }
        public bool IsVisible { get; set; }
        public Category? Category { get; set; }
        public ICollection<Image>? Images { get; set; }
        public ICollection<Discount>? Discounts { get; set; }
    }
}
