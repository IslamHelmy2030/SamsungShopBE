using AutoMapper;
using MediatR;
using SamsungShops.Application.Contracts.Persistence;
using SamsungShops.Application.Models;
using SamsungShops.Domain.Entities;

namespace SamsungShops.Application.Features.HotDeals.Queries.GetVisibleHotDeals
{
    public record GetVisibleHotDealsQuery(int PageNo, int PageSize) :IRequest<ListHandlerResponse<List<HotDealResponse>>>;
    public class GetVisibleHotDealsHandler : IRequestHandler<GetVisibleHotDealsQuery, ListHandlerResponse<List<HotDealResponse>>>
    {
        private readonly IAsyncRepository<HotDeal> _asyncRepository;
        private readonly IMapper _mapper;
        public GetVisibleHotDealsHandler(IAsyncRepository<HotDeal> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository ?? throw new ArgumentException(nameof(asyncRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<ListHandlerResponse<List<HotDealResponse>>> Handle(GetVisibleHotDealsQuery request, CancellationToken cancellationToken)
        {
            var data = await _asyncRepository.GetAsync(x => x.IsVisible, takeRowsCount: request.PageSize, skipRowsCount: request.PageSize);
            var dataMapped = _mapper.Map<List<HotDealResponse>>(data);
            return GetVisibleHotDeals(dataMapped);
        }
        private static ListHandlerResponse<List<HotDealResponse>> GetVisibleHotDeals(List<HotDealResponse> hotDealResponses)
        {
            return new ListHandlerResponse<List<HotDealResponse>>
            {
                Data = hotDealResponses,
                IsSuccess = true,
                TotalDataCount = hotDealResponses.Count
            };
        }
    }
}
