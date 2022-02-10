using Coodesh.Challenge.Business.Models;
using Coodesh.Challenge.Business.Parameters;
using MediatR;
using System.Collections.Generic;

namespace Coodesh.Challenge.Query.Queries.Articles.Find
{
    public class FindArticlesQuery : IRequest<IEnumerable<Article>>
    {
        public PaginationParameters Parameters { get; set; }

        public FindArticlesQuery(PaginationParameters parameters)
        {
            Parameters = parameters;
        }
    }
}