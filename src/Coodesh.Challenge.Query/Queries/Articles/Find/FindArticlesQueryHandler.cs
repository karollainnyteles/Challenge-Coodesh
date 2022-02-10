using Coodesh.Challenge.Business.Contracts.Repositories;
using Coodesh.Challenge.Business.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Coodesh.Challenge.Query.Queries.Articles.Find
{
    public class FindArticlesQueryHandler : IRequestHandler<FindArticlesQuery, IEnumerable<Article>>
    {
        private readonly IArticleReadOnlyRepository _articleReadOnlyRepository;

        public FindArticlesQueryHandler(IArticleReadOnlyRepository articleReadOnlyRepository)
        {
            _articleReadOnlyRepository = articleReadOnlyRepository;
        }

        public async Task<IEnumerable<Article>> Handle(FindArticlesQuery request, CancellationToken cancellationToken)
        {
            var articles = await _articleReadOnlyRepository.FindAsync(request.Parameters);

            return articles;
        }
    }
}