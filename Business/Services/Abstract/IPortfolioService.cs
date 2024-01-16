using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;
using Business.Pagination;

namespace Business.Services.Abstract
{
	public interface IPortfolioService
	{

		public Task UpdateAsync(int id, PortfolioUpdateVM model);
		public Task CreateAsync(PortfolioCreateVM model);
		public Task SoftDeleteAsync(int id);
		public Task RevokeDeleteAsync(int id);
		public Task<GenericPaginatedEntity<PortfolioVM>> GetAllPaginatedAsync(int currentPage, int page, int per_page, string next, string prev, bool includeDeleted);

		public Task<PortfolioVM> GetByIdAsync(int id);
	}
}
