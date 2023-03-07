using SamsungShops.Domain.Common;

namespace SamsungShops.Domain.Entities
{
    public class Discount : EntityBase
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Amount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsExpired { get; set; }
        public string? ProductName { get; set; }
        public int ProductId { get; set; }

        public Product? Product { get; set; }
    }
}
