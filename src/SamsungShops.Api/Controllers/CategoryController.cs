using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamsungShops.Api.Dtos;
using SamsungShops.Application.Features.Categories.Queries.GetAllCategories;
using SamsungShops.Application.Features.Categories.Queries.GetVisibleCategories;

namespace SamsungShops.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetVisibleCategories()
        {

            var request = new GetVisibleCategoriesQuery();
            var result = await _mediator.Send(request);
            var resultDto = _mapper.Map<ListDataResponseDto<List<VisibleCategoryDto>>>(result);
            if (resultDto.IsSuccess)
                return resultDto.Data.Any() ? Ok(resultDto) : NotFound(resultDto);

            resultDto.Message = "Something went worng";
            return BadRequest(resultDto);
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllCategories()
        {
            var request = new GetAllCategoriesQuery();
            var result = await _mediator.Send(request);
            var resultDto = _mapper.Map<ListDataResponseDto<List<CategoryDto>>>(result);
            if (resultDto.IsSuccess)
                return resultDto.Data.Any() ? Ok(resultDto) : NotFound(resultDto);

            resultDto.Message = "Something went worng";
            return BadRequest(resultDto);
        }
    }
}
