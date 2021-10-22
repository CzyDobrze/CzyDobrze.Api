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
using CzyDobrze.Application.Comments.ToExercises.Commands.UpdateExerciseComment;
using CzyDobrze.Application.Exercises.Commands.CreateExercise;
using CzyDobrze.Application.Exercises.Commands.DeleteExercise;
using CzyDobrze.Application.Exercises.Commands.UpdateExercise;
using CzyDobrze.Application.Exercises.Queries.GetExerciseById;
using CzyDobrze.Domain.Content.Answer;
using CzyDobrze.Domain.Content.Comment;
using CzyDobrze.Domain.Content.Exercise;

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
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Exercise))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateExercise(CreateExercise model)
        {
            var exercise = await _mediator.Send(model);
            
            return Created($"/api/exercise/{exercise.Id}", exercise);
        }
        
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Exercise))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Exercise> UpdateExercise(Guid id, UpdateExerciseModel model)
        {
            return await _mediator.Send(new UpdateExercise(id, model.InBookId, model.Description));
        }

        [HttpDelete("{id:guid}")]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExerciseComment))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ExerciseComment> CreateExerciseComment(Guid id, string comment)
        {
            return await _mediator.Send(new CreateExerciseComment(id, comment));
        }


        [HttpPut("{id:guid}/comment")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExerciseComment))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ExerciseComment> UpdateExerciseComment(Guid id, string comment)
        {
            return await _mediator.Send(new UpdateExerciseComment(id, comment));
        }
    }
}