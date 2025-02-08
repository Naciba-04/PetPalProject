using Project.BL.DTOs.ReservationDTO;
using Project.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstraction;

public interface IReservationService
{
    Task<IEnumerable<GetAllReservationDto>> GetAllReservationsAsync();
    Task<GetAllReservationDto> GetReservationByIdAsync(int id);
    Task<bool> UpdateReservationStatusAsync(UpdateReservationDto updateDto);
}