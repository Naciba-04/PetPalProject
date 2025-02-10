using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BL.DTOs.AnimalDTO;
using Project.BL.DTOs.ProductDTO;
using Project.BL.Exceptions;
using Project.BL.Services.Abstraction;
using Project.Core.Model;

namespace Project.MVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AnimalController(IAnimalService _animalService,IMapper _mapper) : Controller
{
    public async Task<IActionResult> Index()
    {
        try
        {
            IEnumerable<GetAllAnimalDto> list = await _animalService.GetAllAsync();

            return View(list);
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateAnimalDto dto)
    {
        
        try
        {
            await _animalService.CreateAsync(dto);
            return RedirectToAction("Index");
        }
        catch (BaseException ex)
        {
            ModelState.AddModelError("CustomError", ex.Message);
            return View(dto);
        }
    }
    public async Task<IActionResult> Update(int id)
    {
        try
        {
            return View(await _animalService.GetByIdForUpdateAsync(id));

        }
        catch (BaseException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(UpdateAnimalDto dto)
    {
       
        try
        {
            await _animalService.UpdateAsync(dto);
            return RedirectToAction("Index");
        }
        catch (BaseException ex)
        {
            ModelState.AddModelError("CustomError", ex.Message);
            return View(dto);
        }
    }

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _animalService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        catch (BaseException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    public async Task<IActionResult> Details(int id)
    {
        try
        {
            var animalDto = await _animalService.GetByIdAsync(id);

            var animal = _mapper.Map<Animal>(animalDto);

            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }



}

