using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BL.DTOs.PetServiceDTO;
using Project.BL.DTOs.PetTypeDTO;
using Project.BL.Exceptions;
using Project.BL.Services.Abstraction;

namespace Project.MVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]

public class PetTypeController(IPetTypeService _petType) : Controller
{
    public async Task<IActionResult> Index()
    {
        IEnumerable<GetAllPetTypeDto> list = await _petType.GetAllAsync();

        return View(list);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreatePetTypeDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        try
        {
            await _petType.CreateAsync(dto);
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
            return View(await _petType.GetByIdForUpdateAsync(id));

        }
        catch (BaseException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(UpdatePetTypeDto updatePetTypeDto)
    {
        if (!ModelState.IsValid)
        {
            return View(updatePetTypeDto);
        }
        await _petType.UpdateAsync(updatePetTypeDto);
        return RedirectToAction("Index", "PetType");
    }

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _petType.DeleteAsync(id);
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
            return View(await _petType.GetByIdReservationAsync(id));
        }
        catch (BaseException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
