using Project.BL.DTOs.AdoptionDTO;
using Project.BL.DTOs.ReservationDTO;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstraction;

public interface IAdoptionService
{
    Task<ICollection<GetAllAdoptionDto>> GetAllAdoptionAsync();
    Task<Adoption?> GetAdoptionByIdAsync(int id);
    Task UpdateAdoptionStatusAsync(UpdateAdoptionDto updateDto);
    Task CreateAdoptionAsync(CreateAdoptionDto createdto);
}
