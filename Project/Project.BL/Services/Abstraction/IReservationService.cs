using Project.BL.DTOs.ReservationDTO;
using Project.Core.Enums;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstraction;


public interface IReservationService
{
    Task<ICollection<GetAllReservationDto>> GetAllReservationsAsync();
    Task<Reservation?> GetReservationByIdAsync(int id);
    Task UpdateReservationStatusAsync(UpdateReservationDto updateDto);
    Task CreateReservationAsync(CreateReservationDto createdto);
}