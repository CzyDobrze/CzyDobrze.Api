using System;
using System.Threading.Tasks;
using CzyDobrze.Application.Textbooks.Command.CreateTextbook;
using CzyDobrze.Application.Textbooks.Queries.GetTextbookById;
using CzyDobrze.Domain.Content.Textbook;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CzyDobrze.Api.Controllers
{
    [ApiController]
    [Route("textbook")]
    public class TextbookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TextbookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        public async Task<Textbook> GetTextbookById(Guid id)
        {
            return await _mediator.Send(new GetTextbookById(id));
        }

        [HttpPost]
        public async Task<Textbook> CreateTextbook(CreateTextbook model)
        {
            return await _mediator.Send(model);
        }
    }
}