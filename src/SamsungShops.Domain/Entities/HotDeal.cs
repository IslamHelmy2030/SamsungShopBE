using SamsungShops.Domain.Common;

namespace SamsungShops.Domain.Entities
{
    public class HotDeal : EntityBase
    {
        public string? ProductName { get; set; }
        public string? ImageFile { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public bool IsVisible { get; set; }
        public int? DiscountId { get; set; }
        public int? ProductId { get; set; }
    }
}
