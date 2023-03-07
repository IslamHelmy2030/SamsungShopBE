using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamsungShops.Api.Dtos;
using SamsungShops.Application.Features.Products.Commands.AddProduct;
using SamsungShops.Application.Features.Products.Commands.DeleteProduct;
using SamsungShops.Application.Features.Products.Commands.UpdateProduct;
using SamsungShops.Application.Features.Products.Queries.GetAllProducts;
using SamsungShops.Application.Features.Products.Queries.GetVisibleProducts;

namespace SamsungShops.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public ProductController(IMediator mediator, IMapper mapper, IConfiguration configuration)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetVisibleProducts(int categoryId)
        {
            var request = new GetVisibleProductsQuery(CategoryId: categoryId);
            var result = await _mediator.Send(request);
            var resultDto = _mapper.Map<ListDataResponseDto<List<VisibleProductDto>>>(result);
            if (resultDto.IsSuccess)
                return resultDto.Data.Any() ? Ok(resultDto) : NotFound(resultDto);
            return BadRequest("Something went worng");
        }
        [HttpGet]
        [Route("All/{categoryId}")]
        public async Task<IActionResult> GetProducts(int categoryId)
        {
            var request = new GetAllProductsQuery(CategoryId: categoryId);
            var result = await _mediator.Send(request);
            var resultDto = _mapper.Map<ListDataResponseDto<List<ProductDto>>>(result);
            if (resultDto.IsSuccess)
                return resultDto.Data.Any() ? Ok(resultDto) : NotFound(resultDto);
            return BadRequest("Something went worng");
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductDto addProduct)
        {
            var addProductData = _mapper.Map<AddProductCommand>(addProduct);
            var result = await _mediator.Send(addProductData);
            var resultDto = _mapper.Map<ProductResponseCommandDto<ProductResponseDto>>(result);
            return (result.IsSuccess) ? Ok(resultDto) : BadRequest("Somthing went wrong");
        }
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto updateProductDto)
        {
            var updateProductData = _mapper.Map<UpdateProductCommand>(updateProductDto);
            var result = await _mediator.Send(updateProductData);
            var resultDto = _mapper.Map<ProductResponseCommandDto<ProductResponseDto>>(result);
            return (result.IsSuccess) ? Ok(resultDto) : BadRequest("Somthing went wrong");
        }
        [HttpPost]
        [Route("Delete/{Id}")]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            var request = new DeleteProductCommandHandlerQuery(Id: Id);
            var result = await _mediator.Send(request);
            var resultDto = _mapper.Map<ProductResponseCommandDto<ProductResponseDto>>(result);
            return (result.IsSuccess) ? Ok(resultDto) : BadRequest("Somthing went wrong");
        }
    }
}
