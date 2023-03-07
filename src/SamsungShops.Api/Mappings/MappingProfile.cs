using AutoMapper;
using SamsungShops.Api.Dtos;
using SamsungShops.Application.Features.Categories.Queries;
using SamsungShops.Application.Features.HotDeals;
using SamsungShops.Application.Features.HotDeals.Commands.AddHotDeal;
using SamsungShops.Application.Features.Products;
using SamsungShops.Application.Features.Products.Commands;
using SamsungShops.Application.Features.Products.Commands.AddProduct;
using SamsungShops.Application.Features.Products.Commands.DeleteProduct;
using SamsungShops.Application.Features.Products.Commands.UpdateProduct;
using SamsungShops.Application.Features.Users;
using SamsungShops.Application.Features.Users.Commands.RegisterUser;
using SamsungShops.Application.Features.Users.Queries.UserLogin;
using SamsungShops.Application.Models;

namespace SamsungShops.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //User Identity
            CreateMap<RegisterUserCommand, RegisterUserDto>().ReverseMap();
            CreateMap<UserManagerResponse, AuthResponseDto>().ReverseMap();
            CreateMap<UserLoginQuery, LoginDto>().ReverseMap();

            //Category
            CreateMap<ListHandlerResponse<List<CategoryResponse>>, ListDataResponseDto<List<VisibleCategoryDto>>>().ReverseMap();
            CreateMap<ListHandlerResponse<List<CategoryResponse>>, ListDataResponseDto<List<CategoryDto>>>().ReverseMap();
            CreateMap<CategoryResponse, CategoryDto>().ReverseMap();
            CreateMap<CategoryResponse, VisibleCategoryDto>().ReverseMap();

            //HotDeals
            CreateMap<ListHandlerResponse<List<HotDealResponse>>, ListDataResponseDto<List<HotDealDto>>>().ReverseMap();
            CreateMap<ListHandlerResponse<List<HotDealResponse>>, ListDataResponseDto<List<VisibleHotDealDto>>>().ReverseMap();
            CreateMap<HotDealResponse, HotDealDto>().ReverseMap();
            CreateMap<HotDealResponse, VisibleHotDealDto>().ReverseMap();

            // Products
            CreateMap<ListHandlerResponse<List<ProductResponse>>, ListDataResponseDto<List<ProductDto>>>().ReverseMap();
            CreateMap<ListHandlerResponse<List<ProductResponse>>, ListDataResponseDto<List<VisibleProductDto>>>().ReverseMap();
            CreateMap<ProductResponse, ProductDto>().ReverseMap();
            CreateMap<ProductResponse, VisibleProductDto>().ReverseMap();

            // Add Product.
            CreateMap<AddProductCommand, AddProductDto>().ReverseMap();
            CreateMap<ProductResponse, ProductResponseDto>().ReverseMap();
            CreateMap<HandlerResponse<ProductResponse>, ProductResponseCommandDto<ProductResponseDto>>().ReverseMap();

            // Update Product.
            CreateMap<UpdateProductCommand, UpdateProductDto>().ReverseMap();

            // Delete Product.
            CreateMap<DeleteProductCommand, DeleteProductDto>().ReverseMap();

            // Add HotDeal.
            CreateMap<AddHotDealCommand, AddHotDealDto>().ReverseMap();
            CreateMap<HotDealResponse, HotDealResponseDto>().ReverseMap();
            CreateMap<HandlerResponse<HotDealResponse>, HotDealResponseCommandDto<HotDealResponseDto>>().ReverseMap();

        }
    }
}
