using AutoMapper;
using MediatR;
using SamsungShops.Application.Contracts.Persistence;
using SamsungShops.Application.Models;
using SamsungShops.Domain.Entities;

namespace SamsungShops.Application.Features.Products.Queries.GetAllProducts
{
    public record GetAllProductsQuery(int CategoryId) : IRequest<ListHandlerResponse<List<ProductResponse>>>;
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, ListHandlerResponse<List<ProductResponse>>>
    {
        public readonly IAsyncRepository<Product> _asyncRepository;
        public readonly IMapper _mapper;
        public GetAllProductsHandler(IAsyncRepository<Product> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository ?? throw new ArgumentNullException(nameof(asyncRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ListHandlerResponse<List<ProductResponse>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _asyncRepository.GetAsync(x => x.CategoryId == request.CategoryId);
            var productsMapped = _mapper.Map<List<ProductResponse>>(products);
            return GetAllProducts(productsMapped);
        }
        private ListHandlerResponse<List<ProductResponse>> GetAllProducts(List<ProductResponse> productResponses)
        {
            return new ListHandlerResponse<List<ProductResponse>>
            {
                Data = productResponses,
                IsSuccess = true,
                TotalDataCount = productResponses.Count
            };
        }
    }
}
