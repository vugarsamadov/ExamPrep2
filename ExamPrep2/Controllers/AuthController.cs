﻿using Microsoft.AspNetCore.Mvc;

namespace ExamPrep2.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
