using AutoMapper;
using MediatR;
using SamsungShops.Application.Contracts.Persistence;
using SamsungShops.Application.Models;
using SamsungShops.Domain.Entities;

namespace SamsungShops.Application.Features.HotDeals.Queries.GetHotDeals
{
    public record GetHotDealsQuery(int PageNo,int PageSize) : IRequest<ListHandlerResponse<List<HotDealResponse>>>;
    public class GetHotDealsHandeler : IRequestHandler<GetHotDealsQuery, ListHandlerResponse<List<HotDealResponse>>>
    {
        private readonly IAsyncRepository<HotDeal> _asyncRepository;
        private readonly IMapper _mapper;
        public GetHotDealsHandeler(IAsyncRepository<HotDeal> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository ?? throw new ArgumentNullException(nameof(asyncRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ListHandlerResponse<List<HotDealResponse>>> Handle(GetHotDealsQuery request, CancellationToken cancellationToken)
        {
            var data = await _asyncRepository.GetAsync(takeRowsCount: request.PageSize, skipRowsCount: request.PageSize);
            var dataMapped = _mapper.Map<List<HotDealResponse>>(data);
            return GetHotDeals(dataMapped);
        }

        private static ListHandlerResponse<List<HotDealResponse>> GetHotDeals(List<HotDealResponse> hotDealResponses)
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
