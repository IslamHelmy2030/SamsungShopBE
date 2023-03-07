using AutoMapper;
using MediatR;
using SamsungShops.Application.Contracts.ObjectStorage;
using SamsungShops.Application.Contracts.Persistence;
using SamsungShops.Application.Models;
using SamsungShops.Domain.Entities;

namespace SamsungShops.Application.Features.HotDeals.Commands.AddHotDeal
{
    public class AddHotDealCommandHandler : IRequestHandler<AddHotDealCommand, HandlerResponse<HotDealResponse>>
    {
        private readonly IAsyncRepository<HotDeal> _asyncRepository;
        private readonly IMapper _mapper;
        private readonly IAsyncObjectStorageRepository _asyncObjectStorageRepository;

        public AddHotDealCommandHandler(IAsyncRepository<HotDeal> asyncRepository, IMapper mapper, IAsyncObjectStorageRepository asyncObjectStorageRepository)
        {
            _asyncRepository = asyncRepository ?? throw new ArgumentNullException(nameof(asyncRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _asyncObjectStorageRepository = asyncObjectStorageRepository ?? throw new ArgumentNullException(nameof(asyncObjectStorageRepository));
        }
        public async Task<HandlerResponse<HotDealResponse>> Handle(AddHotDealCommand request, CancellationToken cancellationToken)
        {
            if (request.ImageBase64 != null)
            {
                var fileModel = new FileModel
                {
                    Content = Convert.FromBase64String(request.ImageBase64),
                    Extension = ".png"
                };
                request.ImageFile = await _asyncObjectStorageRepository.UploadAsync(fileModel);
            }
            var mappedData = _mapper.Map<HotDeal>(request);
            var result = await _asyncRepository.AddAsync(mappedData);
            return HotDealResponseData(result);
        }
        private HandlerResponse<HotDealResponse> HotDealResponseData(HotDeal hotDeal)
        {
            return new HandlerResponse<HotDealResponse>
            {
                Data = _mapper.Map<HotDealResponse>(hotDeal),
                IsSuccess = true
            };
        }
    }
}
