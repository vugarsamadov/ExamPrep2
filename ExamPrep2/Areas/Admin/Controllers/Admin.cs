using Microsoft.AspNetCore.Mvc;

namespace ExamPrep2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Admin : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
