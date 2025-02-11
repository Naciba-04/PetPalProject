using Microsoft.AspNetCore.Mvc;
using Project.BL.Services.Abstraction;
using Project.BL.Services.Implementation;
using Project.Core.Model;
using Project.DAL.Contexts;
using Project.DAL.Repository.Abstaction;

namespace Project.MVC.Controllers;

public class PagesController(PetPatFinalProjectDbContext _context,IRatingService _ratingService,IGenericRepository<Rating> _repository, IAnimalService _animalService, IGenericRepository<Animal> _animalrepository) : Controller
{
    public async Task<IActionResult> CommentDetails()
    {
        var res = await _ratingService.GetAllAsync();
        return View(res);
    }
    public async Task <IActionResult> AllPets()
    {
		var result = await _animalService.GetAllAsync();
		return View(result);
	}
    public async Task <IActionResult> PetDetails(int id)
    {
		var result = await _animalService.GetByIdAsync(id);
		return View(result);
	}
    public IActionResult Gallery()
    {
        return View();
    }
    public IActionResult ReservationPage()
    {
        return View();
    }
    public IActionResult jhbjh()
    {
        return View();
    }
}
