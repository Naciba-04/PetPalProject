using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BL.DTOs.ReservationDTO;
using Project.BL.Exceptions;
using Project.BL.Services.Abstraction;
using System.Diagnostics;

namespace Project.MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        
        return View();
    }
    
}
