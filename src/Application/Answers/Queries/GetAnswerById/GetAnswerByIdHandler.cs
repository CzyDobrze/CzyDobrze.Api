using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Answer;
using MediatR;

namespace CzyDobrze.Application.Answers.Queries.GetAnswerById
{
    public class GetAnswerByIdHandler : IRequestHandler<GetAnswerById, Answer>
    {
        private readonly IAnswerRepository _repository;

        public GetAnswerByIdHandler(IAnswerRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Answer> Handle(GetAnswerById request, CancellationToken cancellationToken)
        {
            var answer = await _repository.ReadById(request.Id);
            if (answer == null) throw new EntityNotFoundException();

            return answer;
        }
    }
}