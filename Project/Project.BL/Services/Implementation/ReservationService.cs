using AutoMapper;
using Project.BL.DTOs.ReservationDTO;
using Project.BL.Services.Abstraction;
using Project.Core.Model;
using Project.DAL.Repository.Abstaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Implementation;

public class ReservationService(IGenericRepository<Reservation> _reservationRepository, IMapper _mapper) : IReservationService
{
    public async Task CreateReservationAsync(CreateReservationDto createdto)
    {
        var map = _mapper.Map<Reservation>(createdto);
        await _reservationRepository.CreateAsync(map);
    }

    public async Task<ICollection<GetAllReservationDto>> GetAllReservationsAsync()
    {
        var reservations = await _reservationRepository.GetAllAsync("PetType", "PetService");
        return _mapper.Map<ICollection<GetAllReservationDto>>(reservations);
    }

    public async Task<Reservation?> GetReservationByIdAsync(int id)
    {
        return await _reservationRepository.GetByIdAsync(id, "PetType", "PetService");
    }

    public async Task UpdateReservationStatusAsync(UpdateReservationDto updateDto)
    {
        var reservation = await _reservationRepository.GetByIdAsync(updateDto.Id);
        if (reservation == null) throw new Exception("Reservation not found");

        reservation.ReservStatus = updateDto.ReservStatus;
        await _reservationRepository.UpdateAsync(reservation);
    }

}
