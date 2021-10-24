using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using CzyDobrze.Api.Models;
using CzyDobrze.Application.Answers.Queries.GetAllAnswersToExercise;
using CzyDobrze.Application.Comments.ToExercises.Commands;
using CzyDobrze.Application.Comments.ToExercises.Commands.CreateExerciseComment;
using CzyDobrze.Application.Comments.ToExercises.Commands.DeleteExerciseComment;
using CzyDobrze.Application.Comments.ToExercises.Commands.UpdateExerciseComment;
using CzyDobrze.Application.Comments.ToExercises.Queries.GetAllCommentsToExercise;
using CzyDobrze.Application.Comments.ToExercises.Queries.GetExerciseCommentById;
using CzyDobrze.Application.Exercises.Commands.CreateExercise;
using CzyDobrze.Application.Exercises.Commands.DeleteExercise;
using CzyDobrze.Application.Exercises.Commands.UpdateExercise;
using CzyDobrze.Application.Exercises.Queries.GetExerciseById;
using CzyDobrze.Application.Votes.ExerciseCommentVotes.ExerciseCommentDownvote;
using CzyDobrze.Application.Votes.ExerciseCommentVotes.ExerciseCommentResetVote;
using CzyDobrze.Application.Votes.ExerciseCommentVotes.ExerciseCommentUpvote;
using CzyDobrze.Domain.Content.Answer;
using CzyDobrze.Domain.Content.Comment;
using CzyDobrze.Domain.Content.Exercise;
using Microsoft.AspNetCore.Authorization;

namespace CzyDobrze.Api.Controllers
{
    [ApiController]
    [Route("/api/exercise")]
    public class ExerciseController : Controller
    {
        private readonly IMediator _mediator;

        public ExerciseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Exercise))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Exercise> GetExerciseById(Guid id)
        {
            return await _mediator.Send(new GetExerciseById(id));
        }
        
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Exercise))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateExercise(CreateExercise model)
        {
            var exercise = await _mediator.Send(model);
            
            return Created($"/api/exercise/{exercise.Id}", exercise);
        }
        
        [HttpPut("{id:guid}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Exercise))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Exercise> UpdateExercise(Guid id, UpdateExerciseModel model)
        {
            return await _mediator.Send(new UpdateExercise(id, model.InBookId, model.Description));
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteExercise(Guid id)
        {
            await _mediator.Send(new DeleteExercise(id));
            return NoContent();
        }

        [HttpGet("{id:guid}/answers")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Answer>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<Answer>> GetAllAnswers(Guid id, int page = 0, int amount = 0)
        {
            return await _mediator.Send(new GetAllAnswersToExercise(id, page, amount));
        }

        [HttpPost("{id:guid}/comment")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExerciseComment))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ExerciseComment> CreateExerciseComment(Guid id, string comment)
        {
            return await _mediator.Send(new CreateExerciseComment(id, comment));
        }
        
        [HttpGet("comment/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExerciseComment))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ExerciseComment> GetExerciseCommentById(Guid id)
        {
            return await _mediator.Send(new GetExerciseCommentById(id));
        }


        [HttpPut("comment/{id:guid}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExerciseComment))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ExerciseComment> UpdateExerciseComment(Guid id, string comment)
        {
            return await _mediator.Send(new UpdateExerciseComment(id, comment));
        }

        [HttpDelete("comment/{id:guid}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteExerciseComment(Guid id)
        {
            await _mediator.Send(new DeleteExerciseComment(id));
            return NoContent();
        }

        [HttpGet("{id:guid}/comments")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerator<ExerciseComment>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<ExerciseComment>> GetAllCommentsToExercise(Guid id, int page = 0, int amount = 10)
        {
            return await _mediator.Send(new GetAllCommentsToExercise(id, page, amount));
        }
        
        [HttpPost("comment/{id:guid}/upvote")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpvoteComment(Guid id)
        {
            await _mediator.Send(new ExerciseCommentUpvote(id));
            return NoContent();
        }
        
        [HttpPost("comment/{id:guid}/downvote")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DownvoteComment(Guid id)
        {
            await _mediator.Send(new ExerciseCommentDownvote(id));
            return NoContent();
        }
                
        [HttpPost("comment/{id:guid}/resetvote")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ResetVoteComment(Guid id)
        {
            await _mediator.Send(new ExerciseCommentResetVote(id));
            return NoContent();
        }
    }
}