using Coodesh.Challenge.Business.Contracts.Repositories;
using Coodesh.Challenge.Business.Models;
using Coodesh.Challenge.Data.Context;
using System.Threading.Tasks;

namespace Coodesh.Challenge.Data.Repositories
{
    public class SynchronizationControlWriteOnlyRepository : ISynchronizationControlWriteOnlyRepository
    {
        private readonly AppDbContext _dbContext;

        public SynchronizationControlWriteOnlyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(SynchronizationControl entity)
        {
            await _dbContext.SynchronizationControls.AddAsync(entity);
        }

        public Task RemoveAsync(int id)
        {
            _dbContext.SynchronizationControls.Remove(new SynchronizationControl { Id = id });
            return Task.CompletedTask;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(SynchronizationControl entity)
        {
            _dbContext.SynchronizationControls.Update(entity);
            return Task.CompletedTask;
        }
    }
}