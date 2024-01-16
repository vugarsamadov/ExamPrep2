using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Models;
using Business.Pagination;
using Business.Services.Abstract;
using Core.Entities;
using Infrastructure.Repositories.Abstract;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Business.Services
{
    public class PortfolioService : IPortfolioService
	{
		private IGenericRepository<Portfolio> _portfolioRepository { get; }
		private IMapper _mapper { get; }

		public PortfolioService(IGenericRepository<Portfolio> portfolioRepository,IMapper mapper)
        {
			_portfolioRepository = portfolioRepository;
			_mapper = mapper;
		}


		public async Task CreateAsync(PortfolioCreateVM model)
		{

			var entity = _mapper.Map<Portfolio>(model);
			await _portfolioRepository.CreateAsync(entity);
			await _portfolioRepository.SaveChangesAsync();
		}

		public async Task<GenericPaginatedEntity<PortfolioVM>> GetAllPaginatedAsync(int currentPage, int page, int per_page,string next,string prev, bool includeDeleted = true)
		{
			var entities = await _portfolioRepository.GetAllPaginatedAsync(page,per_page,false,includeDeleted);
			var models = _mapper.Map<IEnumerable<PortfolioVM>>(entities);
			var count = await _portfolioRepository.GetCountAsync();

			var paginatedModel = new GenericPaginatedEntity<PortfolioVM>(currentPage,per_page,count,next,prev,models);
			return paginatedModel;
		}

		public async Task SoftDeleteAsync(int id)
		{
			var entity = await _portfolioRepository.GetByIdAsync(id, true);
			
			if(entity != null)
				entity.Delete();
			
			await _portfolioRepository.UpdateAsync(entity);
			await _portfolioRepository.SaveChangesAsync();
		}

		public async Task UpdateAsync(int id, PortfolioUpdateVM model)
		{
			var entity = await _portfolioRepository.GetByIdAsync(id, true);

			_mapper.Map(model, entity);

			await _portfolioRepository.UpdateAsync(entity);
			await _portfolioRepository.SaveChangesAsync();
		}

		public async Task RevokeDeleteAsync(int id)
		{
			var entity = await _portfolioRepository.GetByIdAsync(id, true);

			if (entity != null)
				entity.RevokeDelete();

			await _portfolioRepository.UpdateAsync(entity);
			await _portfolioRepository.SaveChangesAsync();
		}

        public async Task<PortfolioVM> GetByIdAsync(int id)
        {
            var entity = await _portfolioRepository.GetByIdAsync(id, false);
			var model = _mapper.Map<PortfolioVM>(entity);
			return model;
        }
    }
}
