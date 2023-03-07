using MediatR;
using SamsungShops.Application.Models;

namespace SamsungShops.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand: IRequest<HandlerResponse<ProductResponse>>
    {
        public int Id { get; set; }
        //public string? Name { get; set; }
        //public string? Summary { get; set; }
        //public string? Description { get; set; }
        //public string? ImageFile { get; set; }
        //public double Price { get; set; }
        //public string? CategoryName { get; set; }
        //public int CategoryId { get; set; }
        public bool IsVisible { get; set; }
    }
}
