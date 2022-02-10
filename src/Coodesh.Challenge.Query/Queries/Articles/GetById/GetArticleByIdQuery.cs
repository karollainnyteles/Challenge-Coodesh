using Coodesh.Challenge.Business.Models;
using MediatR;

namespace Coodesh.Challenge.Query.Queries.Articles.GetById
{
    public class GetArticleByIdQuery : IRequest<Article>
    {
        public int Id { get; set; }

        public GetArticleByIdQuery(int id)
        {
            Id = id;
        }
    }
}