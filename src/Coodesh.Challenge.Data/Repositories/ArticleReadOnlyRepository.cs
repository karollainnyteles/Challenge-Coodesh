using Coodesh.Challenge.Business.Contracts.Repositories;
using Coodesh.Challenge.Business.Models;
using Coodesh.Challenge.Business.Parameters;
using Coodesh.Challenge.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coodesh.Challenge.Data.Repositories
{
    public class ArticleReadOnlyRepository : IArticleReadOnlyRepository
    {
        private readonly AppDbContext _dbContext;

        public ArticleReadOnlyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Article>> FindAsync(PaginationParameters paginationParameters)
        {
            return await _dbContext.Articles
                .OrderBy(a => a.Id)
                .Skip(paginationParameters.GetSkip())
                .Take(paginationParameters.PageSize)
                .ToListAsync();
        }

        public async Task<Article> GetByIdAsync(int id)
        {
            return await _dbContext.Articles
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}