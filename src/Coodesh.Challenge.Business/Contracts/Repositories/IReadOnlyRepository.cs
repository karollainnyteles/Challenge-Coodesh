using Coodesh.Challenge.Business.Models;
using Coodesh.Challenge.Business.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coodesh.Challenge.Business.Contracts.Repositories
{
    public interface IReadOnlyRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> FindAsync(PaginationParameters paginationParameters);
    }
}