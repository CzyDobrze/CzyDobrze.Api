using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CzyDobrze.Api.Models;
using CzyDobrze.Application.Textbooks.Queries.GetTextbookById;
using CzyDobrze.Application.Textbooks.Queries.GetAllTextbooks;
using CzyDobrze.Application.Sections.Queries.GetAllSectionsOfTextbook;
using CzyDobrze.Application.Textbooks.Commands.CreateTextbook;
using CzyDobrze.Application.Textbooks.Commands.DeleteTextbook;
using CzyDobrze.Application.Textbooks.Commands.UpdateTextbook;
using CzyDobrze.Domain.Content.Textbook;
using CzyDobrze.Domain.Content.Section;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CzyDobrze.Api.Controllers
{
    [ApiController]
    [Route("/api/textbook")]
    public class TextbookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TextbookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Textbook))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Textbook> GetTextbookById(Guid id)
        {
            return await _mediator.Send(new GetTextbookById(id));
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Textbook>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<Textbook>> GetAllTextbooks(int page = 0, int amount = 10)
        {
            return await _mediator.Send(new GetAllTextbooks(page, amount));
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Textbook))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateTextbook(CreateTextbook model)
        {
            var textbook = await _mediator.Send(model);

            return Created($"/api/textbook/{textbook.Id}", textbook);
        }
        
        [HttpPut("{id:guid}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Textbook))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Textbook> UpdateTextbook(Guid id, UpdateTextbookModel model)
        {
            return await _mediator.Send(new UpdateTextbook(id, model.Title, model.Subject, model.Publisher, model.ClassYear));
        }
        
        [HttpDelete("{id:guid}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTextbook(Guid id)
        {
            await _mediator.Send(new DeleteTextbook(id));
            return NoContent();
        }
        
        [HttpGet("{id:guid}/sections")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Section>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<Section>> GetAllSectionsOfTextbook(Guid id, int page = 0, int amount = 10)
        {
            return await _mediator.Send(new GetAllSectionsOfTextbook(id, page, amount));
        }
    }
}