using AutoMapper;
using Project.BL.DTOs.PetServiceDTO;
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

public class PetServiceService(IGenericRepository<PetService> _repository, IMapper _mapper) : IPetServiceService
{
    public async Task CreateAsync(CreatePetServiceDto entity)
    {
        var mapper = _mapper.Map<PetService>(entity);
        mapper.CreatedTime = DateTime.Now;
        await _repository.CreateAsync(mapper);
    }

    public async Task DeleteAsync(int id)
    {
        var res = await _repository.GetByIdAsync(id);
        await _repository.DeleteAsync(res);
    }

    public async Task<ICollection<GetAllPetServiceDto>> GetAllAsync()
    {
        var res = await _repository.GetAllAsync("Reservation");
        return _mapper.Map<ICollection<GetAllPetServiceDto>>(res);
    }

    public async Task<ICollection<GetAllPetServiceDto>> GetPetServiceListItemsAsync() => _mapper.Map<ICollection<GetAllPetServiceDto>>(await _repository.GetAllAsync());


    public async Task<GetAllPetServiceDto> GetByIdAsync(int id)
    {
        var res = await _repository.GetByIdAsync(id);
        return _mapper.Map<GetAllPetServiceDto>(res);
    }

    public async Task<UpdatePetServiceDto> GetByIdForUpdateAsync(int id)
    {
        var res = await _repository.GetByIdAsync(id);
        return _mapper.Map<UpdatePetServiceDto>(res);
    }
    public async Task UpdateAsync(UpdatePetServiceDto entity)
    {
        var id = entity.Id;
        var res = await GetByIdAsync(id);
        var mapper = _mapper.Map<PetService>(entity);
        mapper.UpdatedTime = DateTime.Now;
        await _repository.UpdateAsync(mapper);
    }
    public async Task<PetService> GetByIdReservationAsync(int id)
    {
        var res = await _repository.GetByIdAsync(id, "Reservations");
        if (res == null)
        {
            throw new Exception("Entity not Fount");
        }
        var mapper = _mapper.Map<PetService>(res);
        return mapper;
    }
}
