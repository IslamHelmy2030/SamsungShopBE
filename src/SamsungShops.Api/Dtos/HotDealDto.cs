namespace SamsungShops.Api.Dtos
{
    public class HotDealDto
    {
        public string? ProductName { get; set; }
        public string? ImageFile { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public int ProductId { get; set; }
    }
}
