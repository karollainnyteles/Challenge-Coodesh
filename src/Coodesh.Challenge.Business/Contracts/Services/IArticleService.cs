using Coodesh.Challenge.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coodesh.Challenge.Business.Contracts.Services
{
    public interface IArticleService
    {
        Task<int> GetCountAsync();

        Task<List<Article>> Get(int limit, int skip);
    }
}