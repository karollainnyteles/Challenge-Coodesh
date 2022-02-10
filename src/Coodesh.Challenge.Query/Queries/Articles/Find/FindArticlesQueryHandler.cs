using AutoMapper;
using Coodesh.Challenge.Business.Contracts.Repositories;
using Coodesh.Challenge.Query.Queries.Articles.Shared;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Coodesh.Challenge.Query.Queries.Articles.Find
{
    public class FindArticlesQueryHandler : IRequestHandler<FindArticlesQuery, IEnumerable<ArticleResponse>>
    {
        private readonly IArticleReadOnlyRepository _articleReadOnlyRepository;
        private readonly IMapper _mapper;

        public FindArticlesQueryHandler(IArticleReadOnlyRepository articleReadOnlyRepository, IMapper mapper)
        {
            _articleReadOnlyRepository = articleReadOnlyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ArticleResponse>> Handle(FindArticlesQuery request, CancellationToken cancellationToken)
        {
            var articles = await _articleReadOnlyRepository.FindAsync(request.Parameters);

            var articleResponses = _mapper.Map<IEnumerable<ArticleResponse>>(articles);

            return articleResponses;
        }
    }
}