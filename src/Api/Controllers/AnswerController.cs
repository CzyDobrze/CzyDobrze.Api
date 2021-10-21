using System;
using System.Threading.Tasks;
using CzyDobrze.Api.Models;
using CzyDobrze.Application.Answers.Commands.CreateAnswer;
using CzyDobrze.Application.Answers.Commands.DeleteAnswer;
using CzyDobrze.Application.Answers.Commands.UpdateAnswer;
using CzyDobrze.Domain.Content.Answer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CzyDobrze.Api.Controllers
{
    [ApiController]
    [Route("/api/answer")]
    public class AnswerController : Controller
    {
        private readonly IMediator _mediator;
        
        public AnswerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Answer))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAnswer(CreateAnswer model)
        {
            var answer = await _mediator.Send(model);
            
            return Created($"/api/answer/{answer.Id}", answer);
        }
        
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Answer))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Answer> UpdateAnswer(Guid id, UpdateAnswerModel model)
        {
            return await _mediator.Send(new UpdateAnswer(id, model.Content, model.Accepted));
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAnswer(Guid id)
        {
            await _mediator.Send(new DeleteAnswer(id));
            return NoContent();
        }
    }
}