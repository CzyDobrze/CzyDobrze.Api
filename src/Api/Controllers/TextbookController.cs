using System;
using System.Threading.Tasks;
using CzyDobrze.Application.Textbooks.Command.CreateTextbook;
using CzyDobrze.Application.Textbooks.Command.UpdateTextbook;
using CzyDobrze.Application.Textbooks.Queries.GetTextbookById;
using CzyDobrze.Domain.Content.Textbook;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CzyDobrze.Api.Controllers
{
    ///<summary>
    /// Textbook controller
    /// </summary>
    
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
        /// Gets a textbook
        /// </summary>
        /// <returns>A textbook with a given Guid</returns>
        /// <response code="200">When textbook is returned successfully</response>
        /// <response code="400">When validation error occurs</response>
        /// <response code="404">When textbook with given Guid does not exists</response>
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
        /// Creates a new Textbook
        /// </summary>
        /// <returns>A textbook with a given Guid</returns>
        /// <response code="201">When textbook is created successfully</response>
        /// <response code="400">When validation error occurs</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Textbook))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateTextbook(CreateTextbook model)
        {
            var textbook = await _mediator.Send(model);

            return Created($"/api/textbook/{textbook.Id}", textbook);
        }
        
        /// <summary>
        /// Updates an already existing textbook
        /// </summary>
        /// <returns>Updated textbook</returns>
        /// <response code="200">When textbook is updated successfully</response>
        /// <response code="400">When validation error occurs</response>
        /// <response code="404">When no textbook with given Guid was found</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Textbook))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateTextbook(UpdateTextbook model)
        {
            var updatedTextbook = await _mediator.Send(model);

            return Ok();
        }
    }
}