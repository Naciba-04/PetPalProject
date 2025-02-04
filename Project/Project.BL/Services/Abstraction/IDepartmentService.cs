using Project.BL.DTOs.DepartmentDTO;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstraction;

public interface IDepartmentService
{
    Task<ICollection<GetAllDepartmentDto>> GetAllAsync();
    Task<ICollection<GetAllDepartmentDto>> GetDepartmentListItemsAsync();
    Task<UpdateDepartmentDto> GetByIdForUpdateAsync(int id);
    Task<GetAllDepartmentDto> GetByIdAsync(int id);
    Task<Department> GetByIdFoodAsync(int id);
    Task CreateAsync(CreateDepartmentDto entity);
    Task UpdateAsync(UpdateDepartmentDto entity);
    Task DeleteAsync(int id);
}
