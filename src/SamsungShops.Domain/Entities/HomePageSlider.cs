using SamsungShops.Domain.Common;

namespace SamsungShops.Domain.Entities
{
    public class HomePageSlider : EntityBase
    {
        public string? ImageFile { get; set; }
        public string? Description { get; set; }
        public string? Summary { get; set; }
        public bool IsVisible { get; set; }
        public string? ProductName { get; set; }
        public int? ProductId { get; set; }
    }
}
