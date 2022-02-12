using AutoMapper;
using Coodesh.Challenge.Business.Contracts.Repositories;
using Coodesh.Challenge.Business.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Coodesh.Challenge.Command.Commands.Articles.Create
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, CreateArticleResponse>
    {
        private readonly IArticleWriteOnlyRepository _articleWriteOnlyRepository;
        private readonly IMapper _mapper;

        public CreateArticleCommandHandler(IArticleWriteOnlyRepository articleWriteOnlyRepository, IMapper mapper)
        {
            _articleWriteOnlyRepository = articleWriteOnlyRepository;
            _mapper = mapper;
        }

        public async Task<CreateArticleResponse> Handle(CreateArticleCommand command, CancellationToken cancellationToken)
        {
            var article = _mapper.Map<Article>(command);

            await _articleWriteOnlyRepository.AddAsync(article);
            await _articleWriteOnlyRepository.SaveChangesAsync();

            var articleResponse = _mapper.Map<CreateArticleResponse>(article);

            return articleResponse;
        }
    }
}