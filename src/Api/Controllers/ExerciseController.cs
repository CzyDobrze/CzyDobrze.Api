using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
<<<<<<< HEAD
using CzyDobrze.Api.Models;
using CzyDobrze.Application.Exercises.Commands.CreateExercise;
using CzyDobrze.Application.Exercises.Commands.UpdateExercise;
using CzyDobrze.Domain.Content.Exercise;
=======
using CzyDobrze.Application.Exercises.Commands.CreateExercise;
using CzyDobrze.Domain.Content.Section;
>>>>>>> 9e974be46b54cba19c3dafc53c472c94c7a4ed63

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
<<<<<<< HEAD
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Exercise))]
=======
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Section))]
>>>>>>> 9e974be46b54cba19c3dafc53c472c94c7a4ed63
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateExercise(CreateExercise model)
        {
            var exercise = await _mediator.Send(model);
            
            return Created($"/api/exercise/{exercise.Id}", exercise);
        }
<<<<<<< HEAD
        
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Exercise))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Exercise> UpdateSection(Guid id, UpdateExerciseModel model)
        {
            return await _mediator.Send(new UpdateExercise(id, model.InBookId, model.Description));
        }
=======
>>>>>>> 9e974be46b54cba19c3dafc53c472c94c7a4ed63
    }
}