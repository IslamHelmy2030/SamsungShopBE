using AutoMapper;
using MediatR;
using SamsungShops.Application.Contracts.Persistence;
using SamsungShops.Application.Models;
using SamsungShops.Domain.Entities;

namespace SamsungShops.Application.Features.Products.Queries.GetVisibleProducts
{
    public record GetVisibleProductsQuery(int CategoryId) : IRequest<ListHandlerResponse<List<ProductResponse>>>;

    public class GetVisibleProductsHandler : IRequestHandler<GetVisibleProductsQuery, ListHandlerResponse<List<ProductResponse>>>
    {
        private readonly IAsyncRepository<Product> _asyncRepository;
        private readonly IMapper _mapper;

        public GetVisibleProductsHandler(IAsyncRepository<Product> repository, IMapper mapper)
        {
            _asyncRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<ListHandlerResponse<List<ProductResponse>>> Handle(GetVisibleProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _asyncRepository.GetAsync(x => x.IsVisible && x.CategoryId == request.CategoryId);
            var productsMapped = _mapper.Map<List<ProductResponse>>(products);
            return GetVisibleProducts(productsMapped);
        }
        private ListHandlerResponse<List<ProductResponse>> GetVisibleProducts(List<ProductResponse> productResponses)
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
