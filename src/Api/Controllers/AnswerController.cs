using System.Threading.Tasks;
using CzyDobrze.Application.Answers.Commands.CreateAnswer;
using CzyDobrze.Domain.Content.Answer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CzyDobrze.Api.Controllers
{
    [ApiController]
<<<<<<< HEAD
    [Route("/api/answer")]
=======
>>>>>>> b1a0c43a151ef7b5a2741e2129b0e924a0e36581
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
    }
}