﻿using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class FoodItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
