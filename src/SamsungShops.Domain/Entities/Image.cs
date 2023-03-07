using SamsungShops.Domain.Common;

namespace SamsungShops.Domain.Entities
{
    public class Image : EntityBase
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageFile { get; set; }
        public string? ProductName { get; set; }
        public int ProductId { get; set; }

        public Product? Product { get; set; }
    }
}
