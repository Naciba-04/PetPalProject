using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BL.DTOs.AdoptionDTO;
using Project.BL.DTOs.ReservationDTO;
using Project.BL.EmailServices.Abstraction;
using Project.BL.Services.Abstraction;
using Project.Core.Enums;

namespace Project.MVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AdoptionController(IAdoptionService _adoptionService, IEmailService _emailService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var adoptions = await _adoptionService.GetAllAdoptionAsync();
        return View(adoptions);
    }

    public async Task<IActionResult> Details(int id)
    {
        var adoption = await _adoptionService.GetAdoptionByIdAsync(id);
        if (adoption == null)
        {
            return NotFound();
        }
        return View(adoption);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateStatus(int id, string newStatus)
    {
        var adoption = await _adoptionService.GetAdoptionByIdAsync(id);
        if (adoption == null)
        {
            return NotFound();
        }

        if (!Enum.TryParse(newStatus, out ReservStatus status))
        {
            return BadRequest("Yanlış status seçildi.");
        }

        var updateDto = new UpdateAdoptionDto
        {
            Id = id,
            ReservStatus = status
        };

        await _adoptionService.UpdateAdoptionStatusAsync(updateDto);

        if (status == ReservStatus.Accepted)
        {
            _emailService.SendAdoptionAcceptedEmail(adoption.Email);
        }
        else if (status == ReservStatus.Rejected)
        {
            _emailService.SendAdoptionRejectedEmail(adoption.Email);
        }
        return RedirectToAction("Index");
    }
}
