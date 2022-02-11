using Coodesh.Challenge.Business.Contracts.Repositories;
using Coodesh.Challenge.Business.Models;
using Coodesh.Challenge.Data.Context;
using System;
using System.Threading.Tasks;

namespace Coodesh.Challenge.Data.Repositories
{
    public class LaunchWriteOnlyRepository : ILaunchWriteOnlyRepository
    {
        private readonly AppDbContext _dbContext;

        public LaunchWriteOnlyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Launch entity)
        {
            await _dbContext.AddAsync(entity);
        }

        public Task RemoveAsync(Guid id)
        {
            _dbContext.Remove(new Launch { Id = id });
            return Task.CompletedTask;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(Launch entity)
        {
            _dbContext.Update(entity);
            return Task.CompletedTask;
        }
    }
}