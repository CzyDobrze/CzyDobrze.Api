using System;
using System.Threading.Tasks;
using CzyDobrze.Application.Textbooks.Command.CreateTextbook;
using CzyDobrze.Application.Textbooks.Queries.GetTextbookById;
using CzyDobrze.Domain.Content.Textbook;
using MediatR;
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

        /// <summary>
        /// Gets an existing textbook
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retrieved textbook</returns>
        /// <response code="200">When a textbook is returned correctly</response>
        /// <response code="400">When a validation error occurs</response>
        /// <response code="404">When a textbook with given id does not exist</response>
        /// <response code="500">When there is an unhandled exception</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Textbook))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Textbook> GetTextbookById(Guid id)
        {
            return await _mediator.Send(new GetTextbookById(id));
        }

        /// <summary>
        /// Creates a new textbook
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Created textbook</returns>
        /// <response code="201">When a textbook is created correctly</response>
        /// <response code="400">When a validation error occurs</response>
        /// <response code="500">When there is an unhandled exception</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Textbook))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateTextbook(CreateTextbook model)
        {
            var textbook = await _mediator.Send(model);

            return Created($"/api/textbook/{textbook.Id}", textbook);
        }
    }
}