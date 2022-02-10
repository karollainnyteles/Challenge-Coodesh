using Coodesh.Challenge.Business.Contracts.Repositories;
using Coodesh.Challenge.Business.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Coodesh.Challenge.Query.Queries.Articles.GetById
{
    public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, Article>
    {
        private readonly IArticleReadOnlyRepository _articleReadOnlyRepository;

        public GetArticleByIdQueryHandler(IArticleReadOnlyRepository articleReadOnlyRepository)
        {
            _articleReadOnlyRepository = articleReadOnlyRepository;
        }

        public async Task<Article> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            var article = await _articleReadOnlyRepository.GetByIdAsync(request.Id);

            return article;
        }
    }
}