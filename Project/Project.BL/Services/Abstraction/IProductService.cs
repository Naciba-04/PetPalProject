using Project.BL.DTOs.ProductDTO;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstraction
{
    public interface IProductService
    {
        Task<ICollection<GetAllProductDto>> GetAllAsync();
        Task<GetAllProductDto> GetByIdAsync(int id);
        Task<UpdateProductDto> GetByIdForUpdateAsync(int id);
        Task<Product> GetByIdWithChildrenAsync(int id);
        Task CreateAsync(CreateProductDto entity);
        Task UpdateAsync(UpdateProductDto entity);
        Task DeleteAsync(int id);
    }
}
