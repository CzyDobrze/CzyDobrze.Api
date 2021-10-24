using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using CzyDobrze.Api.Models;
using CzyDobrze.Application.Sections.Commands.CreateSection;
using CzyDobrze.Application.Sections.Commands.DeleteSection;
using CzyDobrze.Application.Sections.Commands.UpdateSection;
using CzyDobrze.Application.Sections.Queries.GetSectionById;
using CzyDobrze.Domain.Content.Section;
using System.Collections.Generic;
using CzyDobrze.Application.Exercises.Queries.GetAllExercisesFromSection;
using CzyDobrze.Domain.Content.Exercise;

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
        
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Section))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Section> UpdateSection(Guid id, UpdateSectionModel model)
        {
            return await _mediator.Send(new UpdateSection(id, model.Title, model.Description));
        }
        
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSection(Guid id)
        {
            await _mediator.Send(new DeleteSection(id));
            return NoContent();
        }

        [HttpGet("{id:guid}/exercises")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Exercise>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<Exercise>> GetAllExercisesFromSection(Guid id, int page = 0, int amount = 10)
        {
            return await _mediator.Send(new GetAllExercisesFromSection(id, page, amount));
        }
    }
}