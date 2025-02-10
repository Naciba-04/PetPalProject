using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Project.BL.DTOs.AnimalDTO;
using Project.BL.DTOs.ProductDTO;
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

public class AnimalService(IGenericRepository<Animal> _repository, IMapper _mapper, IWebHostEnvironment _env) : IAnimalService
{
    public async Task CreateAsync(CreateAnimalDto entity)
    {
        var mapper = _mapper.Map<Animal>(entity);
        mapper.CreatedTime = DateTime.Now;

        mapper.CoverImageUrl = await entity.CoverImage.SaveAsync("animals");

        await _repository.CreateAsync(mapper);
    }

    public async Task DeleteAsync(int id)
    {
        var place = await _repository.GetByIdAsync(id);
        await _repository.DeleteAsync(place);
        File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "animals", place.CoverImageUrl));
    }

	public async Task<ICollection<GetAllAnimalDto>> GetAllAsync()
    {
        var res = await _repository.GetAllAsync();
        return _mapper.Map<ICollection<GetAllAnimalDto>>(res);
    }

    public async Task<GetAllAnimalDto> GetByIdAsync(int id)
    {
        var res = await _repository.GetByIdAsync(id);
        return _mapper.Map<GetAllAnimalDto>(res);
    }
    public async Task<Animal> GetByIdProductAsync(int id)
    {
        var res = await _repository.GetByIdAsync(id);
        return _mapper.Map<Animal>(res);
    }
    public async Task<UpdateAnimalDto> GetByIdForUpdateAsync(int id)
    {
        var res = await _repository.GetByIdAsync(id);
        return _mapper.Map<UpdateAnimalDto>(res);
    }

    public async Task UpdateAsync(UpdateAnimalDto dto)
    {
        var oldPlace = await GetByIdAsync(dto.Id);
        var place = _mapper.Map<Animal>(dto);

        place.CoverImageUrl = dto.CoverImage is not null ? await dto.CoverImage.SaveAsync("animals") : oldPlace.CoverImageUrl;

        await _repository.UpdateAsync(place);

        if (dto.CoverImage is not null) File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "animals", oldPlace.CoverImageUrl));
    }
}
