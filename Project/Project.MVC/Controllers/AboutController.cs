﻿using Microsoft.AspNetCore.Mvc;

namespace Project.MVC.Controllers;

public class AboutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
