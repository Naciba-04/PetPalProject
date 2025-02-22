using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Project.BL.DTOs.ProductDTO;
using Project.BL.DTOs.WorkerDTO;
using Project.BL.Exceptions;
using Project.BL.Services.Abstraction;
using Project.BL.Utilities;
using Project.Core.Model;
using Project.DAL.Repository.Abstaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Implementation;

public class WorkerService(IGenericRepository<Worker> _repository, IGenericRepository<WorkerDepartment> _departmentrepository, IMapper _mapper, IWebHostEnvironment _env) : IWorkerService
{
    public async Task CreateAsync(CreateWorkerDto entity)
    {
        if (await _departmentrepository.GetByIdAsync(entity.WorkerDepartmentId) is null) throw new BaseException("Department not found!");

        var mapper = _mapper.Map<Worker>(entity);
        mapper.CreatedTime = DateTime.Now;

        mapper.ProfileImageUrl = await entity.ProfileImage.SaveAsync("workers");

        await _repository.CreateAsync(mapper);
    }

    public async Task DeleteAsync(int id)
    {
        var place = await _repository.GetByIdAsync(id);
        await _repository.DeleteAsync(place);
        File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "workers", place.ProfileImageUrl));
    }
    public async Task<Worker> GetByIdWithChildrenAsync(int id) => await _repository.GetByIdAsync(id, includes: "WorkerDepartment") ?? throw new BaseException();

    public async Task<ICollection<GetAllWorkerDto>> GetAllAsync()
    {
        var res = await _repository.GetAllAsync("WorkerDepartment");
        return _mapper.Map<ICollection<GetAllWorkerDto>>(res);
    }

    public async Task<GetAllWorkerDto> GetByIdAsync(int id)
    {
        var res = await _repository.GetByIdAsync(id, "WorkerDepartment");
        return _mapper.Map<GetAllWorkerDto>(res);
    }
    public async Task<Worker> GetByIdWorkerAsync(int id)
    {
        var res = await _repository.GetByIdAsync(id);
        return _mapper.Map<Worker>(res);
    }
    public async Task<UpdateWorkerDto> GetByIdForUpdateAsync(int id)
    {
        var res = await _repository.GetByIdAsync(id);
        return _mapper.Map<UpdateWorkerDto>(res);
    }

    public async Task UpdateAsync(UpdateWorkerDto dto)
    {
        if (await _departmentrepository.GetByIdAsync(dto.WorkerDepartmentId) is null) throw new BaseException("Department not found!");

        var oldPlace = await GetByIdAsync(dto.Id);
        var place = _mapper.Map<Worker>(dto);

        place.ProfileImageUrl = dto.ProfileImage is not null ? await dto.ProfileImage.SaveAsync("workers") : oldPlace.ProfileImageUrl;

        await _repository.UpdateAsync(place);

        if (dto.ProfileImage is not null) File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "workers", oldPlace.ProfileImageUrl));
    }
}

