using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using CzyDobrze.Application.Sections.Commands.CreateSection;
using CzyDobrze.Application.Sections.Queries.GetSectionById;
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

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Section))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Section> GetSectionById(Guid id)
        {
            return await _mediator.Send(new GetSectionById(id));
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