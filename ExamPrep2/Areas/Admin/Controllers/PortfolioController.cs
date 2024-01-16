using System.Runtime.CompilerServices;
using AutoMapper;
using Business.Models;
using Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Execution;

namespace ExamPrep2.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class PortfolioController : Controller
	{
        private IPortfolioService _portfolioService { get; }
        public IMapper _mapper { get; }

        public PortfolioController(IPortfolioService portfolioService,IMapper mapper)
        {
            _portfolioService = portfolioService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
		{
			var model = await _portfolioService.GetAllPaginatedAsync(1, 1, 4, null, null,true);
			var model2 = new PortfolioIndexVM();
			model2.Portfolios = model;
			return View(model2);
		}


		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			var model = await _portfolioService.GetByIdAsync(id);
			var updateModel = _mapper.Map<PortfolioUpdateVM>(model);
			return View(updateModel);
		}


		[HttpPost]
		public async Task<IActionResult> Update(int id, PortfolioUpdateVM model)
		{
			if (!ModelState.IsValid) return View(model);
			await _portfolioService.UpdateAsync(id, model);
            return RedirectToAction(nameof(Index));
        }




		[HttpGet]
        public IActionResult Create()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> Create(PortfolioCreateVM model)
		{ 
			if (!ModelState.IsValid) return View(model);

			await _portfolioService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
		{
			await _portfolioService.SoftDeleteAsync(id);
			return RedirectToAction(nameof(Index));	
		}
		public async Task<IActionResult> RevokeDelete(int id)
		{
			await _portfolioService.RevokeDeleteAsync(id);
			return RedirectToAction(nameof(Index));	
		}



	}
}
