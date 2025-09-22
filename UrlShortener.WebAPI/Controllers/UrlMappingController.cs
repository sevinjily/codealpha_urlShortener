using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application.Features.Commands.CreateUrl;
using UrlShortener.Application.Features.Queries.GetOriginUrl;
using UrlShortener.Application.Features.Queries.GetShortCodeByOriginUrl;

namespace UrlShortener.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlMappingController : ControllerBase
    {
        private readonly IMediator mediator;

        public UrlMappingController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUrl(CreateUrlMappingCommand command)
        {
            var result=await mediator.Send(command);

            if(!result.isSuccess)
                return BadRequest(new { message = result.Message });


            return Ok(new { message = result.Message, value = result.Value });


        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetOriginUrl([FromQuery]GetOriginUrlQuery query)
        {
            var result = await mediator.Send(query);

            if (!result.isSuccess)
                return BadRequest(new { message = result.Message });


            return Ok(new { message = result.Message, value = result.Value });
         
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetShortCode([FromQuery] GetShortCodeByOriginUrlQuery query)
        {
            var result = await mediator.Send(query);

            if (!result.isSuccess)
                return BadRequest(new { message = result.Message });


            return Ok(new { message = result.Message, value = result.Value });

        }
    }
}
