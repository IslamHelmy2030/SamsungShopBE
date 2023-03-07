using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamsungShops.Api.Dtos;
using SamsungShops.Application.Features.HotDeals.Commands.AddHotDeal;
using SamsungShops.Application.Features.HotDeals.Commands.UpdateHotDeal;
using SamsungShops.Application.Features.HotDeals.Queries.GetHotDeals;
using SamsungShops.Application.Features.HotDeals.Queries.GetVisibleHotDeals;

namespace SamsungShops.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HotDealsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public HotDealsController(IMediator mediator, IMapper mapper, IConfiguration configuration)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        [HttpGet]
        [Route("All/{pageNumber}")]
        public async Task<IActionResult> GetHotDeales(int pageNumber)
        {
            var pageSize = Convert.ToInt32(_configuration.GetValue<string>("ApiSettings:PageDataSize"));
            var request = new GetHotDealsQuery(PageNo: pageNumber, PageSize: pageSize);
            var result = await _mediator.Send(request);
            var resultDto = _mapper.Map<ListDataResponseDto<List<HotDealDto>>>(result);
            if (resultDto.IsSuccess)
                return resultDto.Data.Any() ? Ok(resultDto) : NotFound(resultDto);
            return BadRequest("Something went worng");
        }

        [HttpGet("{pageNumber}")]
        public async Task<IActionResult> GetVisibleHotDeales(int pageNumber)
        {
            var pageSize = Convert.ToInt32(_configuration.GetValue<string>("ApiSettings:HomePageDataSize"));
            var request = new GetVisibleHotDealsQuery(PageNo: pageNumber, PageSize: pageSize);
            var result = await _mediator.Send(request);
            var resultDto = _mapper.Map<ListDataResponseDto<List<VisibleHotDealDto>>>(result);
            if (resultDto.IsSuccess)
                return resultDto.Data.Any() ? Ok(resultDto) : NotFound(resultDto);
            return BadRequest("Something went worng");
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddHotDeal(AddHotDealDto addHotDealDto)
        {
            var addHotDeal = _mapper.Map<AddHotDealCommand>(addHotDealDto);
            var result= await _mediator.Send(addHotDeal);
            var resultDto = _mapper.Map<HotDealResponseCommandDto<HotDealResponseDto>>(result);
            return result.IsSuccess ? Ok(resultDto) : BadRequest("Somthing went wrong");
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateHotDeal(UpdateHotDealDto updateHotDealDto)
        {
            var updateHotDeal = _mapper.Map<UpdateHotDealCommand>(updateHotDealDto);
            var result = await _mediator.Send(updateHotDeal);
            var resultDto = _mapper.Map<HotDealResponseCommandDto<HotDealResponseDto>>(result);
            return result.IsSuccess ? Ok(resultDto) : BadRequest("Somthing went wrong");

        }
    }
}
