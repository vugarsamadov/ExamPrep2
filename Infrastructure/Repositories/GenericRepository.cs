using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	internal class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private ApplicationDbContext _dbContext { get; }

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);    
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FirstOrDefaultAsync(c=>c.Id == id);
            if(entity != null)
                _dbContext.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllPaginatedAsync(int? page, int? per_page, bool tracking, bool includeDeleted = true)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            
            if (page != null && per_page != null)
                query.Skip((int)((page-1)*per_page)).Take((int)per_page);
            if(!includeDeleted)
                query = query.Where(e=>e.IsDeleted == false);

            var entities = await query.ToListAsync();

            return entities;
		}

        public async Task<T> GetByIdAsync(int id, bool tracking)
        {
			var query = _dbContext.Set<T>().AsQueryable();
			if (!tracking)
				query = query.AsNoTracking();
            var entity = await query.FirstOrDefaultAsync(c => c.Id ==  id);
            
            return entity;
		}

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(T entity)
        {
            _dbContext.Update(entity);
            return Task.CompletedTask;
        }

		public async Task<int> GetCountAsync()
		{
			return await _dbContext.Set<T>().CountAsync();
		}

    }
}
