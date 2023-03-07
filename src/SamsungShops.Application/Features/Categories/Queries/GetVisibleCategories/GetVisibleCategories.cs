using AutoMapper;
using MediatR;
using SamsungShops.Application.Contracts.Persistence;
using SamsungShops.Application.Models;
using SamsungShops.Domain.Entities;

namespace SamsungShops.Application.Features.Categories.Queries.GetVisibleCategories
{
    public record GetVisibleCategoriesQuery : IRequest<ListHandlerResponse<List<CategoryResponse>>>;

    public class GetVisibleCategoriesHandler : IRequestHandler<GetVisibleCategoriesQuery, ListHandlerResponse<List<CategoryResponse>>>
    {
        private readonly IAsyncRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetVisibleCategoriesHandler(IAsyncRepository<Category> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ListHandlerResponse<List<CategoryResponse>>> Handle(GetVisibleCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repository.GetAsync(x => x.IsVisible);
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
