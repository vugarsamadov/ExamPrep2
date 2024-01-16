using System.Diagnostics;
using Business.Services.Abstract;
using ExamPrep2.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamPrep2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPortfolioService portfolioService;
        private readonly IWebHostEnvironment host;

        public HomeController(ILogger<HomeController> logger,IPortfolioService portfolioService, IWebHostEnvironment _host)
        {
            _logger = logger;
            this.portfolioService = portfolioService;
            host = _host;
        }

        public async Task<IActionResult> Index()
        {
            var models = await portfolioService.GetAllPaginatedAsync(1,1,5,null,null,false);


            return View(models);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}