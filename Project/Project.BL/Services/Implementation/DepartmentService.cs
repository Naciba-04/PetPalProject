using AutoMapper;
using Project.BL.DTOs.DepartmentDTO;
using Project.BL.Exceptions;
using Project.BL.Services.Abstraction;
using Project.Core.Model;
using Project.DAL.Repository.Abstaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Implementation;

public class DepartmentService(IGenericRepository<Department> _repository,IMapper _mapper) : IDepartmentService
{
    public async Task CreateAsync(CreateDepartmentDto entity)
    {
        var mapper = _mapper.Map<Department>(entity);
        mapper.CreatedTime = DateTime.Now;
        await _repository.CreateAsync(mapper);
    }

    public async Task DeleteAsync(int id)
    {
        var res = await _repository.GetByIdAsync(id);
        await _repository.DeleteAsync(res);
    }

    public async Task<ICollection<GetAllDepartmentDto>> GetAllAsync()
    {
        var res = await _repository.GetAllAsync();
        return _mapper.Map<ICollection<GetAllDepartmentDto>>(res);
    }

    public async Task<ICollection<GetAllDepartmentDto>> GetDepartmentListItemsAsync() => _mapper.Map<ICollection<GetAllDepartmentDto>>(await _repository.GetAllAsync());


    public async Task<GetAllDepartmentDto> GetByIdAsync(int id)
    {
        var res = await _repository.GetByIdAsync(id);
        return _mapper.Map<GetAllDepartmentDto>(res);
    }

    public async Task<UpdateDepartmentDto> GetByIdForUpdateAsync(int id)
    {
        var res = await _repository.GetByIdAsync(id);
        return _mapper.Map<UpdateDepartmentDto>(res);
    }
    public async Task UpdateAsync(UpdateDepartmentDto entity)
    {
        var id = entity.Id;
        var res = await GetByIdAsync(id);
        var mapper = _mapper.Map<Department>(entity);
        mapper.UpdatedTime = DateTime.Now;
        await _repository.UpdateAsync(mapper);
    }

    public async Task<Department> GetByIdProductAsync(int id)
    {
        var res = await _repository.GetByIdAsync(id, "Products");
        if (res == null)
        {
            throw new Exception("Entity not Fount");
        }
        var mapper = _mapper.Map<Department>(res);
        return mapper;
    }
}
