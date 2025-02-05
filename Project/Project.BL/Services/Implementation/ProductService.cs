using AutoMapper;
using Microsoft.AspNetCore.Hosting;
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

public class ProductService(IGenericRepository<Product> _repository, IGenericRepository<Department> _departmentrepository,IMapper _mapper,IWebHostEnvironment _env) : IProductService
{
    public async Task CreateAsync(CreateProductDto entity)
    {
        if (await _departmentrepository.GetByIdAsync(entity.DepartmentId) is null) throw new BaseException("Department not found!");

        var mapper = _mapper.Map<Product>(entity);
        mapper.CreatedTime = DateTime.Now;

        mapper.CoverImageUrl = await entity.CoverImage.SaveAsync("products");

        await _repository.CreateAsync(mapper);
    }

    public async Task DeleteAsync(int id)
    {
        var place = await _repository.GetByIdAsync(id);
        await _repository.DeleteAsync(place);
        File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "products", place.CoverImageUrl));
    }
    public async Task<Product> GetByIdWithChildrenAsync(int id) => await _repository.GetByIdAsync(id, includes: "Department") ?? throw new BaseException();

    public async Task<ICollection<GetAllProductDto>> GetAllAsync()
    {
        var res = await _repository.GetAllAsync("Department");
        return _mapper.Map<ICollection<GetAllProductDto>>(res);
    }

    public async Task<GetAllProductDto> GetByIdAsync(int id)
    {
        var res = await _repository.GetByIdAsync(id);
        return _mapper.Map<GetAllProductDto>(res);
    }
    public async Task<Product> GetByIdProductAsync(int id)
    {
        var res = await _repository.GetByIdAsync(id);
        return _mapper.Map<Product>(res);
    }
    public async Task<UpdateProductDto> GetByIdForUpdateAsync(int id)
    {
        var res = await _repository.GetByIdAsync(id);
        return _mapper.Map<UpdateProductDto>(res);
    }

    public async Task UpdateAsync(UpdateProductDto dto)
    {
        if (await _departmentrepository.GetByIdAsync(dto.DepartmentId) is null) throw new BaseException("Department not found!");

        var oldPlace = await GetByIdAsync(dto.Id);
        var place = _mapper.Map<Product>(dto);

        place.CoverImageUrl = dto.CoverImage is not null ? await dto.CoverImage.SaveAsync("products") : oldPlace.CoverImageUrl;

        await _repository.UpdateAsync(place);

        if (dto.CoverImage is not null) File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "products", oldPlace.CoverImageUrl));
    }
}
