using Coodesh.Challenge.Business.Models;
using System.Threading.Tasks;

namespace Coodesh.Challenge.Business.Contracts.Repositories
{
    public interface IWriteOnlyRepository<TEntity, Tkey> where TEntity : Entity<Tkey>
    {
        Task AddAsync(TEntity entity);

        Task RemoveAsync(Tkey id);

        Task UpdateAsync(TEntity entity);

        Task<int> SaveChangesAsync();
    }
}