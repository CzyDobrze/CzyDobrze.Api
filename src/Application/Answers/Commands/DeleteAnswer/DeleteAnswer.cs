using System;
using MediatR;

namespace CzyDobrze.Application.Answers.Commands.DeleteAnswer
{
    public class DeleteAnswer : IRequest
    {
        public DeleteAnswer(Guid id)
        {
            Id = id;
        }

        public Guid Id;
    }
}