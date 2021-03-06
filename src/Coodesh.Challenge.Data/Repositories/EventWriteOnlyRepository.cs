using Coodesh.Challenge.Business.Contracts.Repositories;
using Coodesh.Challenge.Business.Models;
using Coodesh.Challenge.Data.Context;
using System.Threading.Tasks;

namespace Coodesh.Challenge.Data.Repositories
{
    public class EventWriteOnlyRepository : IEventWriteOnlyRepository
    {
        private readonly AppDbContext _dbContext;

        public EventWriteOnlyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Event entity)
        {
            await _dbContext.AddAsync(entity);
        }

        public Task RemoveAsync(int id)
        {
            _dbContext.Remove(new Event { Id = id });
            return Task.CompletedTask;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(Event entity)
        {
            _dbContext.Update(entity);
            return Task.CompletedTask;
        }
    }
}