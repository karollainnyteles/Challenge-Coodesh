using Coodesh.Challenge.Business.Models;
using System.Threading.Tasks;

namespace Coodesh.Challenge.Business.Contracts.Repositories
{
    public interface ISynchronizationControlReadOnlyRepository : IReadOnlyRepository<SynchronizationControl, int>
    {
        Task<SynchronizationControl> GetLast();
    }
}