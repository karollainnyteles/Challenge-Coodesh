using Coodesh.Challenge.Business.Models;

namespace Coodesh.Challenge.Business.Contracts.Repositories
{
    public interface IArticleWriteOnlyRepository : IWriteOnlyRepository<Article, int>
    {
    }
}