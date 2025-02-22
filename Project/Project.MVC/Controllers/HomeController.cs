using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.BL.DTOs.ReservationDTO;
using Project.BL.Exceptions;
using Project.BL.Services.Abstraction;
using Project.DAL.Contexts;
using System.Diagnostics;

namespace Project.MVC.Controllers;

public class HomeController(PetPatFinalProjectDbContext _context) : Controller
{
    public async Task<IActionResult> Index()
    {
        return View(await _context.Workers.Include(x => x.WorkerDepartment).ToListAsync());
    }
}
