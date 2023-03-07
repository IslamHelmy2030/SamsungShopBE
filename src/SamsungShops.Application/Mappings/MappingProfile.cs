using AutoMapper;
using SamsungShops.Application.Features.Categories.Queries;
using SamsungShops.Application.Features.HotDeals;
using SamsungShops.Application.Features.HotDeals.Commands.AddHotDeal;
using SamsungShops.Application.Features.HotDeals.Commands.UpdateHotDeal;
using SamsungShops.Application.Features.Products;
using SamsungShops.Application.Features.Products.Commands.AddProduct;
using SamsungShops.Application.Features.Products.Commands.DeleteProduct;
using SamsungShops.Application.Features.Products.Commands.UpdateProduct;
using SamsungShops.Application.Features.Users.Commands.RegisterUser;
using SamsungShops.Domain.Entities;
using SamsungShops.Domain.IdentityEntities;

namespace SamsungShops.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, RegisterUserCommand>().ReverseMap();
            CreateMap<Category, CategoryResponse>().ReverseMap();
            CreateMap<Product, ProductResponse>().ReverseMap();
            CreateMap<Product, AddProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<ProductResponse, UpdateProductCommand>().ReverseMap();
            CreateMap<Product, DeleteProductCommand>().ReverseMap();
            CreateMap<ProductResponse, DeleteProductCommand>().ReverseMap();
            CreateMap<HotDealResponse, AddHotDealCommand>().ReverseMap();
            CreateMap<HotDealResponse, UpdateHotDealCommand>().ReverseMap();
        }
    }
}
