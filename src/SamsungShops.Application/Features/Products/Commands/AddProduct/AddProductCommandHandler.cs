using AutoMapper;
using MediatR;
using SamsungShops.Application.Contracts.ObjectStorage;
using SamsungShops.Application.Contracts.Persistence;
using SamsungShops.Application.Models;
using SamsungShops.Domain.Entities;

namespace SamsungShops.Application.Features.Products.Commands.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, HandlerResponse<ProductResponse>>
    {
        private readonly IAsyncRepository<Product> _asyncRepository;
        private readonly IMapper _mapper;
        private readonly IAsyncObjectStorageRepository _asyncObjectStorageRepository;
        public AddProductCommandHandler(IAsyncRepository<Product> asyncRepository, IMapper mapper, IAsyncObjectStorageRepository asyncObjectStorageRepository)
        {
            _asyncRepository = asyncRepository ?? throw new ArgumentNullException(nameof(asyncRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _asyncObjectStorageRepository= asyncObjectStorageRepository?? throw new ArgumentNullException(nameof(asyncObjectStorageRepository));
        }
        public async Task<HandlerResponse<ProductResponse>> Handle(AddProductCommand request, CancellationToken cancellationToken)
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
            var productMapped = _mapper.Map<Product>(request);
            var result = await _asyncRepository.AddAsync(productMapped);
            return ProductResponseData(result);
        }
        private HandlerResponse<ProductResponse> ProductResponseData(Product product)
        {
            return new HandlerResponse<ProductResponse>
            {
                Data = _mapper.Map<ProductResponse>(product),
                IsSuccess = true
            };
        }
    }
}
