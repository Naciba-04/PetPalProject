using Project.BL.DTOs.PetServiceDTO;
using Project.BL.DTOs.PetTypeDTO;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstraction;

public interface IPetServiceService
{
    Task<ICollection<GetAllPetServiceDto>> GetAllAsync();
    Task<ICollection<GetAllPetServiceDto>> GetPetServiceListItemsAsync();
    Task<UpdatePetServiceDto> GetByIdForUpdateAsync(int id);
    Task<GetAllPetServiceDto> GetByIdAsync(int id);
    Task<PetService> GetByIdReservationAsync(int id);
    Task CreateAsync(CreatePetServiceDto entity);
    Task UpdateAsync(UpdatePetServiceDto entity);
    Task DeleteAsync(int id);
}
