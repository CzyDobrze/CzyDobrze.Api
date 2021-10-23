using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CzyDobrze.Api.Models;
using CzyDobrze.Application.Answers.Commands.CreateAnswer;
using CzyDobrze.Application.Answers.Commands.DeleteAnswer;
using CzyDobrze.Application.Answers.Commands.UpdateAnswer;
using CzyDobrze.Application.Answers.Queries.GetAnswerById;
using CzyDobrze.Application.Comments.ToAnswers.Commands.CreateAnswerComment;
using CzyDobrze.Application.Comments.ToAnswers.Commands.DeleteAnswerComment;
using CzyDobrze.Application.Comments.ToAnswers.Commands.UpdateAnswerComment;
using CzyDobrze.Application.Comments.ToAnswers.Queries.GetAllCommentsToAnswer;
using CzyDobrze.Application.Comments.ToAnswers.Queries.GetAnswerCommentById;
using CzyDobrze.Domain.Content.Answer;
using CzyDobrze.Domain.Content.Comment;
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
        
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Answer))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Answer> GetAnswerById(Guid id)
        {
            return await _mediator.Send(new GetAnswerById(id));
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Answer))]
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

        [HttpPost("{id:guid}/comment")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AnswerComment))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<AnswerComment> CreateAnswerComment(Guid id, string content)
        {
            return await _mediator.Send(new CreateAnswerComment(id, content));
        }
        
        [HttpPut("comment/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AnswerComment))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<AnswerComment> UpdateAnswerComment(Guid id, string content)
        {
            return await _mediator.Send(new UpdateAnswerComment(id, content));
        }

        [HttpDelete("comment/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAnswerComment(Guid id)
        {
            await _mediator.Send(new DeleteAnswerComment(id));
            return NoContent();
        }

        [HttpGet("{id:guid}/comments")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AnswerComment>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<AnswerComment>> GetAllCommentsToAnswer(Guid id, int page = 0, int amount = 10)
        {
            return await _mediator.Send(new GetAllCommentsToAnswer(id, page, amount));
        }
        
        [HttpGet("/comment/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AnswerComment))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<AnswerComment> GetAnswerCommentById(Guid id)
        {
            return await _mediator.Send(new GetAnswerCommentById(id));
        }
    }
}