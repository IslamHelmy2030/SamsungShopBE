using AutoMapper;
using MediatR;
using SamsungShops.Application.Contracts.ObjectStorage;
using SamsungShops.Application.Contracts.Persistence;
using SamsungShops.Application.Models;
using SamsungShops.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamsungShops.Application.Features.HotDeals.Commands.UpdateHotDeal
{
    public class UpdateHotDealHandler : IRequestHandler<UpdateHotDealCommand, HandlerResponse<HotDealResponse>>
    {
        private readonly IAsyncRepository<HotDeal> _asyncRepository;
        private readonly IMapper _mapper;
        private readonly IAsyncObjectStorageRepository _asyncObjectStorageRepository;
        public UpdateHotDealHandler(IAsyncRepository<HotDeal> asyncRepository, IMapper mapper, IAsyncObjectStorageRepository asyncObjectStorageRepository)
        {
            _asyncRepository = asyncRepository ?? throw new ArgumentNullException(nameof(asyncRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _asyncObjectStorageRepository = asyncObjectStorageRepository ?? throw new ArgumentNullException(nameof(asyncObjectStorageRepository));
        }
        public async Task<HandlerResponse<HotDealResponse>> Handle(UpdateHotDealCommand request, CancellationToken cancellationToken)
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
            await _asyncRepository.UpdateAsync(mappedData);
            return HotDealResponseData(request);
        }
        private HandlerResponse<HotDealResponse> HotDealResponseData(UpdateHotDealCommand request)
        {
            return new HandlerResponse<HotDealResponse>
            {
                Data = _mapper.Map<HotDealResponse>(request),
                IsSuccess = true
            };
        }
    }
}
