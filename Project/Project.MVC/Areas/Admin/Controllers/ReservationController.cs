using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BL.DTOs.ReservationDTO;
using Project.BL.EmailServices.Abstraction;
using Project.BL.Services.Abstraction;
using Project.Core.Enums;

namespace Project.MVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class ReservationController(IReservationService _reservationService, IEmailService _emailService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var reservations = await _reservationService.GetAllReservationsAsync();
        return View(reservations);
    }

    public async Task<IActionResult> Details(int id)
    {
        var reservation = await _reservationService.GetReservationByIdAsync(id);
        if (reservation == null)
        {
            return NotFound();
        }
        return View(reservation);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateStatus(int id, string newStatus)
    {
        var reservation = await _reservationService.GetReservationByIdAsync(id);
        if (reservation == null)
        {
            return NotFound();
        }

        if (!Enum.TryParse(newStatus, out ReservStatus status))
        {
            return BadRequest("Yanlış status seçildi.");
        }

        var updateDto = new UpdateReservationDto
        {
            Id = id,
            ReservStatus = status
        };

        await _reservationService.UpdateReservationStatusAsync(updateDto);

        if (status == ReservStatus.Accepted)
        {
            _emailService.SendAcceptedEmail(reservation.Email);
        }
        else if (status == ReservStatus.Rejected)
        {
            _emailService.SendRejectedEmail(reservation.Email);
        }
       


        return RedirectToAction("Index");
    }
}
