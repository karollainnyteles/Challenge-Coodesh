using Coodesh.Challenge.Business.Contracts.Repositories;
using Coodesh.Challenge.Business.Models;
using Coodesh.Challenge.Data.Context;
using System.Threading.Tasks;

namespace Coodesh.Challenge.Data.Repositories
{
    public class ArticleWriteOnlyRepository : IArticleWriteOnlyRepository
    {
        private readonly AppDbContext _dbContext;

        public ArticleWriteOnlyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Article entity)
        {
            await _dbContext.Articles.AddAsync(entity);
        }

        public Task RemoveAsync(int id)
        {
            _dbContext.Articles.Remove(new Article { Id = id });
            return Task.CompletedTask;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(Article entity)
        {
            _dbContext.Articles.Update(entity);
            return Task.CompletedTask;
        }
    }
}