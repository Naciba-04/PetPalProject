using AutoMapper;
using Project.BL.DTOs.ProductDTO;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductDto, Product>().ReverseMap();
        CreateMap<UpdateProductDto, Product>().ReverseMap();
        CreateMap<GetAllProductDto, Product>().ReverseMap()
               .ForMember(dest => dest.DepartmentName, options => options.MapFrom(src => src.Department.Name));

    }
}
