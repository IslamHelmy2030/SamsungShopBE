namespace SamsungShops.Api.Dtos
{
    public class VisibleProductDto
    {
        public string? Name { get; set; }
        public string? Summary { get; set; }
        public string? Description { get; set; }
        public string? ImageFile { get; set; }
        public double Price { get; set; }
        public string? CategoryName { get; set; }
        public int CategoryId { get; set; }
        public bool IsVisible { get; set; }
    }
}
