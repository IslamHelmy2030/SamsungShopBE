using AutoMapper;
using MediatR;
using SamsungShops.Application.Contracts.Persistence;
using SamsungShops.Application.Models;
using SamsungShops.Domain.Entities;

namespace SamsungShops.Application.Features.Categories.Queries.GetAllCategories
{
    public record GetAllCategoriesQuery : IRequest<ListHandlerResponse<List<CategoryResponse>>>;

    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, ListHandlerResponse<List<CategoryResponse>>>
    {
        private readonly IAsyncRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetAllCategoriesHandler(IAsyncRepository<Category> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ListHandlerResponse<List<CategoryResponse>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repository.GetAllAsync();
            var CategoriesResponse = _mapper.Map<List<CategoryResponse>>(categories);

            return GetResponse(CategoriesResponse);
        }

        private static ListHandlerResponse<List<CategoryResponse>> GetResponse(List<CategoryResponse> Categories)
        {
            return new ListHandlerResponse<List<CategoryResponse>>
            {
                Data = Categories,
                IsSuccess = true,
                TotalDataCount = Categories.Count
            };
        }
    }
}
