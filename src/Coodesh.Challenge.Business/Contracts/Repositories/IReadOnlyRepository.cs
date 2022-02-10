using Coodesh.Challenge.Business.Models;
using Coodesh.Challenge.Business.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coodesh.Challenge.Business.Contracts.Repositories
{
    public interface IReadOnlyRepository<TEntity, Tkey> where TEntity : Entity<Tkey>
    {
        Task<TEntity> GetByIdAsync(Tkey id);

        Task<IEnumerable<TEntity>> FindAsync(PaginationParameters paginationParameters);
    }
}