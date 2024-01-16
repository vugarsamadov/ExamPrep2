using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Abstract
{
    public interface IGenericRepository<T>
    {

        public Task<T> GetByIdAsync(int id,bool tracking);
        public Task<IEnumerable<T>> GetAllPaginatedAsync(int? page,int? per_page,bool tracking,bool includeDeleted);
        public Task CreateAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task SaveChangesAsync();
        public Task DeleteByIdAsync(int id);
        public Task<int> GetCountAsync();
    }
}
