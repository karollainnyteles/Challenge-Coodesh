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
    public class SynchronizationControlReadOnlyRepository : ISynchronizationControlReadOnlyRepository
    {
        private readonly AppDbContext _dbContext;

        public SynchronizationControlReadOnlyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SynchronizationControl>> FindAsync(PaginationParameters paginationParameters)
        {
            return await _dbContext.SynchronizationControls
                .AsNoTracking()
                .OrderBy(a => a.Id)
                .Skip(paginationParameters.GetSkip())
                .Take(paginationParameters.PageSize)
                .ToListAsync();
        }

        public async Task<SynchronizationControl> GetByIdAsync(int id)
        {
            return await _dbContext.SynchronizationControls
               .AsNoTracking()
               .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<SynchronizationControl> GetLast()
        {
            return await _dbContext.SynchronizationControls
               .AsNoTracking()
               .OrderBy(a => a.Id)
               .LastOrDefaultAsync();
        }
    }
}