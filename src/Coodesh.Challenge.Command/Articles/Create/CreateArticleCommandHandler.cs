using AutoMapper;
using Coodesh.Challenge.Business.Contracts.Repositories;
using Coodesh.Challenge.Business.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Coodesh.Challenge.Command.Articles.Create
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, Article>
    {
        private readonly IArticleWriteOnlyRepository _articleWriteOnlyRepository;
        private readonly IMapper _mapper;

        public CreateArticleCommandHandler(IArticleWriteOnlyRepository articleWriteOnlyRepository, IMapper mapper)
        {
            _articleWriteOnlyRepository = articleWriteOnlyRepository;
            _mapper = mapper;
        }

        public async Task<Article> Handle(CreateArticleCommand command, CancellationToken cancellationToken)
        {
            var article = _mapper.Map<Article>(command);

            await _articleWriteOnlyRepository.AddAsync(article);

            return article;
        }
    }
}