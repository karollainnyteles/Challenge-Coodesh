using Coodesh.Challenge.Business.Models;
using System.Threading.Tasks;

namespace Coodesh.Challenge.Business.Contracts.Repositories
{
    public interface IWriteOnlyRepository<in TEntity> where TEntity : Entity
    {
        Task AddAsync(TEntity entity);

        Task RemoveAsync(int id);

        Task UpdateAsync(TEntity entity);
    }
}