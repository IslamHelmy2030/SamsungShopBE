namespace SamsungShops.Application.Features.HotDeals.Queries
{
    public class HotDealResponse
    {
        public string? ProductName { get; set; }
        public string? ImageFile { get; set; }
        public double? Price { get; set; }
        public double? Discount { get; set; }
        public int? ProductId { get; set; }
    }
}
