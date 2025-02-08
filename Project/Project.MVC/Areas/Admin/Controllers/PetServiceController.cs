using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BL.DTOs.DepartmentDTO;
using Project.BL.DTOs.PetServiceDTO;
using Project.BL.Exceptions;
using Project.BL.Services.Abstraction;
using Project.BL.Services.Implementation;

namespace Project.MVC.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class PetServiceController(IPetServiceService _petService) : Controller
{
    public async Task<IActionResult> Index()
    {
        IEnumerable<GetAllPetServiceDto> list = await _petService.GetAllAsync();

        return View(list);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreatePetServiceDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        try
        {
            await _petService.CreateAsync(dto);
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
            return View(await _petService.GetByIdForUpdateAsync(id));

        }
        catch (BaseException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(UpdatePetServiceDto updatePetServiceDto)
    {
        if (!ModelState.IsValid)
        {
            return View(updatePetServiceDto);
        }
        await _petService.UpdateAsync(updatePetServiceDto);
        return RedirectToAction("Index", "PetService");
    }

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _petService.DeleteAsync(id);
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
            return View(await _petService.GetByIdReservationAsync(id));
        }
        catch (BaseException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
