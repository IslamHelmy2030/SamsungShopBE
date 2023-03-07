using AutoMapper;
using MediatR;
using SamsungShops.Application.Contracts.Persistence;
using SamsungShops.Application.Models;
using SamsungShops.Domain.Entities;

namespace SamsungShops.Application.Features.Products.Commands.DeleteProduct
{
    public record DeleteProductCommandHandlerQuery(int Id):IRequest<HandlerResponse<ProductResponse>>;
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandHandlerQuery, HandlerResponse<ProductResponse>>
    {
        private readonly IAsyncRepository<Product> _asyncRepository;
        private readonly IMapper _mapper;
        public DeleteProductCommandHandler(IAsyncRepository<Product> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository ?? throw new ArgumentNullException(nameof(asyncRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<HandlerResponse<ProductResponse>> Handle(DeleteProductCommandHandlerQuery request, CancellationToken cancellationToken)
        {
            var product = await _asyncRepository.GetByIdAsync(request.Id);
            product.IsVisible = false;
            //var productMapped = _mapper.Map<Product>(product);
            await _asyncRepository.DeleteAsync(product);
            return ProductResponseData();
        }
        private HandlerResponse<ProductResponse> ProductResponseData()
        {
            return new HandlerResponse<ProductResponse>()
            {
               // Data = _mapper.Map<ProductResponse>(deleteProductCommand),
                IsSuccess = true
            };
        }
    }
}
