using AutoMapper;
using Project.BL.DTOs.AdoptionDTO;
using Project.BL.DTOs.ReservationDTO;
using Project.BL.Services.Abstraction;
using Project.Core.Model;
using Project.DAL.Repository.Abstaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Implementation;

public class AdoptionService(IGenericRepository<Adoption> _adoptionRepository,IMapper _mapper) :IAdoptionService
{
    public async Task CreateAdoptionAsync(CreateAdoptionDto createdto)
    {
        var map = _mapper.Map<Adoption>(createdto);
        await _adoptionRepository.CreateAsync(map);
    }

    public async Task<ICollection<GetAllAdoptionDto>> GetAllAdoptionAsync()
    {
        var adoptions = await _adoptionRepository.GetAllAsync();
        return _mapper.Map<ICollection<GetAllAdoptionDto>>(adoptions);
    }

    public async Task<Adoption?> GetAdoptionByIdAsync(int id)
    {
        return await _adoptionRepository.GetByIdAsync(id);
    }

    public async Task UpdateAdoptionStatusAsync(UpdateAdoptionDto updateDto)
    {
        var adoption = await _adoptionRepository.GetByIdAsync(updateDto.Id);
        if (adoption == null) throw new Exception("Adoption not found");

        adoption.ReservStatus = updateDto.ReservStatus;
        await _adoptionRepository.UpdateAsync(adoption);
    }

}
