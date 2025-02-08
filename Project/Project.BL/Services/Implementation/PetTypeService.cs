using AutoMapper;
using Project.BL.DTOs.DepartmentDTO;
using Project.BL.DTOs.PetTypeDTO;
using Project.BL.Services.Abstraction;
using Project.Core.Model;
using Project.DAL.Repository.Abstaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Implementation;

public class PetTypeService(IGenericRepository<PetType> _repository, IMapper _mapper) : IPetTypeService
{
    public async Task CreateAsync(CreatePetTypeDto entity)
    {
        var mapper = _mapper.Map<PetType>(entity);
        mapper.CreatedTime = DateTime.Now;
        await _repository.CreateAsync(mapper);
    }

    public async Task DeleteAsync(int id)
    {
        var res = await _repository.GetByIdAsync(id);
        await _repository.DeleteAsync(res);
    }

    public async Task<ICollection<GetAllPetTypeDto>> GetAllAsync()
    {
        var res = await _repository.GetAllAsync();
        return _mapper.Map<ICollection<GetAllPetTypeDto>>(res);
    }

    public async Task<ICollection<GetAllPetTypeDto>> GetPetTypeListItemsAsync() => _mapper.Map<ICollection<GetAllPetTypeDto>>(await _repository.GetAllAsync());


    public async Task<GetAllPetTypeDto> GetByIdAsync(int id)
    {
        var res = await _repository.GetByIdAsync(id);
        return _mapper.Map<GetAllPetTypeDto>(res);
    }

    public async Task<UpdatePetTypeDto> GetByIdForUpdateAsync(int id)
    {
        var res = await _repository.GetByIdAsync(id);
        return _mapper.Map<UpdatePetTypeDto>(res);
    }
    public async Task UpdateAsync(UpdatePetTypeDto entity)
    {
        var id = entity.Id;
        var res = await GetByIdAsync(id);
        var mapper = _mapper.Map<PetType>(entity);
        mapper.UpdatedTime = DateTime.Now;
        await _repository.UpdateAsync(mapper);
    }
    public async Task<PetType> GetByIdReservationAsync(int id)
    {
        var res = await _repository.GetByIdAsync(id, "Reservations");
        if (res == null)
        {
            throw new Exception("Entity not Fount");
        }
        var mapper = _mapper.Map<PetType>(res);
        return mapper;
    }

}
