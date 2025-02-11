using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BL.DTOs.AdoptionDTO;
using Project.BL.DTOs.ReservationDTO;
using Project.BL.EmailServices.Abstraction;
using Project.BL.Exceptions;
using Project.BL.Services.Abstraction;
using Project.BL.Services.Implementation;
using Project.Core.Model;
using Project.DAL.Contexts;
using Project.DAL.Repository.Abstaction;

namespace Project.MVC.Controllers;

public class PagesController(PetPatFinalProjectDbContext _context, IRatingService _ratingService, IGenericRepository<Rating> _repository, IAnimalService _animalService, IGenericRepository<Animal> _animalrepository, IEmailService _emailService, IAdoptionService _adoptionService) : Controller
{
    public async Task<IActionResult> CommentDetails()
    {
        var res = await _ratingService.GetAllAsync();
        return View(res);
    }
    public async Task<IActionResult> AllPets()
    {
        var result = await _animalService.GetAllAsync();
        return View(result);
    }
    public async Task<IActionResult> PetDetails(int id)
    {
        var result = await _animalService.GetByIdAsync(id);
        return View(result);
    }
    public IActionResult CreateAdoption()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateAdoption(CreateAdoptionDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        try
        {
            await _adoptionService.CreateAdoptionAsync(dto);
            _emailService.AdoptionMessage(dto.Email);
            return RedirectToAction("AllPets", "Pages");
        }
        catch (BaseException ex)
        {
            ModelState.AddModelError("CustomError", ex.Message);
            return View(dto);
        }
        
    }
    public IActionResult Gallery()
    {
        return View();
    }


}
