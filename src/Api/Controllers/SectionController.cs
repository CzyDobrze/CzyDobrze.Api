using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using CzyDobrze.Application.Sections.Commands.CreateSection;
using CzyDobrze.Domain.Content.Section;

namespace CzyDobrze.Api.Controllers
{
    [ApiController]
    [Route("/api/section")]
    public class SectionController : Controller
    {
        private readonly IMediator _mediator;

        public SectionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Section))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateSection(CreateSection model)
        {
            var section = await _mediator.Send(model);

            return Created($"/api/section/{section.Id}", section);
        }
    }
}