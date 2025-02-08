using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BL.DTOs.ReservationDTO;
using Project.BL.EmailServices.Abstraction;
using Project.BL.Exceptions;
using Project.BL.Services.Abstraction;

namespace Project.MVC.Controllers;

public class ReservationController(IReservationService _reservservice, IPetServiceService _petservice, IPetTypeService _pettypeservice,IEmailService _emailservice) : Controller
{
   
    public async Task<IActionResult> Create()
    {

        try
        {
            ViewData["PetTypeName"] = new SelectList(await _pettypeservice.GetAllAsync(), "Id", "Name");
            ViewData["PetServiceName"] = new SelectList(await _petservice.GetAllAsync(), "Id", "Name");
            return View();
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateReservationDto dto)
    {
        if (!ModelState.IsValid)
        {
            ViewData["PetTypeName"] = new SelectList(await _pettypeservice.GetAllAsync(), "Id", "Name");
            ViewData["PetServiceName"] = new SelectList(await _petservice.GetAllAsync(), "Id", "Name");
            return View(dto);
        }

        try
        {
            await _reservservice.CreateReservationAsync(dto);
            _emailservice.ReservMessage(dto.Email);
            return RedirectToAction("Index","Home");
        }
        catch (BaseException ex)
        {
            ViewData["PetTypeName"] = new SelectList(await _pettypeservice.GetAllAsync(), "Id", "Name");
            ViewData["PetServiceName"] = new SelectList(await _petservice.GetAllAsync(), "Id", "Name");
            ModelState.AddModelError("CustomError", ex.Message);
            return View(dto);
        }
        catch (Exception)
        {
            ViewData["PetTypeName"] = new SelectList(await _pettypeservice.GetAllAsync(), "Id", "Name");
            ViewData["PetServiceName"] = new SelectList(await _petservice.GetAllAsync(), "Id", "Name");
            ModelState.AddModelError("CustomError", "Something went wrong!");
            return View(dto);
        }
    }
}
