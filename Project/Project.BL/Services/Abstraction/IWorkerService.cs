using Project.BL.DTOs.ProductDTO;
using Project.BL.DTOs.WorkerDTO;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstraction;

public interface IWorkerService
{
    Task<ICollection<GetAllWorkerDto>> GetAllAsync();
    Task<GetAllWorkerDto> GetByIdAsync(int id);
    Task<Worker> GetByIdWorkerAsync(int id);
    Task<UpdateWorkerDto> GetByIdForUpdateAsync(int id);
    Task<Worker> GetByIdWithChildrenAsync(int id);
    Task CreateAsync(CreateWorkerDto entity);
    Task UpdateAsync(UpdateWorkerDto entity);
    Task DeleteAsync(int id);
}
