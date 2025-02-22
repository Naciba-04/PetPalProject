using Project.BL.DTOs.DepartmentDTO;
using Project.BL.DTOs.WorkerDepartmentDTO;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstraction;

public interface IWorkerDepartmentService
{
    Task<ICollection<GetAllWorkerDepartmentDto>> GetAllAsync();
    Task<ICollection<GetAllWorkerDepartmentDto>> GetDepartmentListItemsAsync();
    Task<UpdateWorkerDepartmentDto> GetByIdForUpdateAsync(int id);
    Task<GetAllWorkerDepartmentDto> GetByIdAsync(int id);
    Task<WorkerDepartment> GetByIdWorkerAsync(int id);
    Task CreateAsync(CreateWorkerDepartmentDto entity);
    Task UpdateAsync(UpdateWorkerDepartmentDto entity);
    Task DeleteAsync(int id);
}
