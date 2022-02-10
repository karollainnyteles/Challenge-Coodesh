using AutoMapper;
using Coodesh.Challenge.Business.Contracts.Repositories;
using Coodesh.Challenge.Query.Queries.Articles.Shared;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Coodesh.Challenge.Query.Queries.Articles.GetById
{
    public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, ArticleResponse>
    {
        private readonly IArticleReadOnlyRepository _articleReadOnlyRepository;
        private readonly IMapper _mapper;

        public GetArticleByIdQueryHandler(IArticleReadOnlyRepository articleReadOnlyRepository, IMapper mapper)
        {
            _articleReadOnlyRepository = articleReadOnlyRepository;
            _mapper = mapper;
        }

        public async Task<ArticleResponse> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            var article = await _articleReadOnlyRepository.GetByIdAsync(request.Id);

            var articleResponse = _mapper.Map<ArticleResponse>(article);

            return articleResponse;
        }
    }
}