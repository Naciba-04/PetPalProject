using AutoMapper;
using Project.BL.DTOs.DepartmentDTO;
using Project.BL.DTOs.WorkerDepartmentDTO;
using Project.BL.Services.Abstraction;
using Project.Core.Model;
using Project.DAL.Repository.Abstaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Implementation;

public class WorkerDepartmentService(IGenericRepository<WorkerDepartment> _repository, IMapper _mapper) : IWorkerDepartmentService
{
    public async Task CreateAsync(CreateWorkerDepartmentDto entity)
    {
        var mapper = _mapper.Map<WorkerDepartment>(entity);
        mapper.CreatedTime = DateTime.Now;
        await _repository.CreateAsync(mapper);
    }

    public async Task DeleteAsync(int id)
    {
        var res = await _repository.GetByIdAsync(id);
        await _repository.DeleteAsync(res);
    }

    public async Task<ICollection<GetAllWorkerDepartmentDto>> GetAllAsync()
    {
        var res = await _repository.GetAllAsync();
        return _mapper.Map<ICollection<GetAllWorkerDepartmentDto>>(res);
    }

    public async Task<ICollection<GetAllWorkerDepartmentDto>> GetDepartmentListItemsAsync() => _mapper.Map<ICollection<GetAllWorkerDepartmentDto>>(await _repository.GetAllAsync());


    public async Task<GetAllWorkerDepartmentDto> GetByIdAsync(int id)
    {
        var res = await _repository.GetByIdAsync(id);
        return _mapper.Map<GetAllWorkerDepartmentDto>(res);
    }

    public async Task<UpdateWorkerDepartmentDto> GetByIdForUpdateAsync(int id)
    {
        var res = await _repository.GetByIdAsync(id);
        return _mapper.Map<UpdateWorkerDepartmentDto>(res);
    }
    public async Task UpdateAsync(UpdateWorkerDepartmentDto entity)
    {
        var id = entity.Id;
        var res = await GetByIdAsync(id);
        var mapper = _mapper.Map<WorkerDepartment>(entity);
        mapper.UpdatedTime = DateTime.Now;
        await _repository.UpdateAsync(mapper);
    }

    public async Task<WorkerDepartment> GetByIdWorkerAsync(int id)
    {
        var res = await _repository.GetByIdAsync(id, "Workers");
        if (res == null)
        {
            throw new Exception("Entity not Fount");
        }
        var mapper = _mapper.Map<WorkerDepartment>(res);
        return mapper;
    }
}
