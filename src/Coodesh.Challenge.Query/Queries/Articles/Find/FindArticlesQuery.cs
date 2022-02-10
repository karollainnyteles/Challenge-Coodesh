using Coodesh.Challenge.Business.Parameters;
using Coodesh.Challenge.Query.Queries.Articles.Shared;
using MediatR;
using System.Collections.Generic;

namespace Coodesh.Challenge.Query.Queries.Articles.Find
{
    public class FindArticlesQuery : IRequest<IEnumerable<ArticleResponse>>
    {
        public PaginationParameters Parameters { get; set; }

        public FindArticlesQuery(PaginationParameters parameters)
        {
            Parameters = parameters;
        }
    }
}