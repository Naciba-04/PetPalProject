using AutoMapper;
using Project.BL.DTOs.AnimalDTO;
using Project.BL.DTOs.ProductDTO;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Profiles;

public class AnimalProfile:Profile
{
    public AnimalProfile()
    {
        CreateMap<CreateAnimalDto, Animal>().ReverseMap();
        CreateMap<UpdateAnimalDto, Animal>().ReverseMap();
        CreateMap<GetAllAnimalDto, Animal>().ReverseMap()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()));
    }
}
