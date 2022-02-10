using Coodesh.Challenge.Query.Queries.Articles.Shared;
using MediatR;

namespace Coodesh.Challenge.Query.Queries.Articles.GetById
{
    public class GetArticleByIdQuery : IRequest<ArticleResponse>
    {
        public int Id { get; set; }

        public GetArticleByIdQuery(int id)
        {
            Id = id;
        }
    }
}