using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using CzyDobrze.Api.Models;
using CzyDobrze.Application.Exercises.Commands.CreateExercise;
using CzyDobrze.Application.Exercises.Commands.DeleteExercise;
using CzyDobrze.Application.Exercises.Commands.UpdateExercise;
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
    }
}