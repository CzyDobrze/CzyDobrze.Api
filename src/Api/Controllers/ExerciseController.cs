using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using CzyDobrze.Application.Exercises.Commands.CreateExercise;
using CzyDobrze.Domain.Content.Section;

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
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Section))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateExercise(CreateExercise model)
        {
            var exercise = await _mediator.Send(model);
            
            return Created($"/api/exercise/{exercise.Id}", exercise);
        }
    }
}