using Project.BL.DTOs.DepartmentDTO;
using Project.BL.DTOs.PetTypeDTO;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstraction;

public interface IPetTypeService
{
    Task<ICollection<GetAllPetTypeDto>> GetAllAsync();
    Task<ICollection<GetAllPetTypeDto>> GetPetTypeListItemsAsync();
    Task<UpdatePetTypeDto> GetByIdForUpdateAsync(int id);
    Task<GetAllPetTypeDto> GetByIdAsync(int id);
    Task<PetType> GetByIdReservationAsync(int id);
    Task CreateAsync(CreatePetTypeDto entity);
    Task UpdateAsync(UpdatePetTypeDto entity);
    Task DeleteAsync(int id);
}
