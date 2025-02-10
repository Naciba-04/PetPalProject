using Project.BL.DTOs.AnimalDTO;
using Project.BL.DTOs.ProductDTO;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstraction;

public interface IAnimalService
{
    Task<ICollection<GetAllAnimalDto>> GetAllAsync();
    Task<GetAllAnimalDto> GetByIdAsync(int id);
    Task<Animal> GetByIdProductAsync(int id);
	Task<UpdateAnimalDto> GetByIdForUpdateAsync(int id);
    Task CreateAsync(CreateAnimalDto entity);
    Task UpdateAsync(UpdateAnimalDto entity);
    Task DeleteAsync(int id);
}
