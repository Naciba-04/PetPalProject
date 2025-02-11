using AutoMapper;
using Project.BL.DTOs.AnimalDTO;
using Project.BL.DTOs.ProductDTO;
using Project.Core.Enums;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Profiles;


public class AnimalProfile : Profile
{
	public AnimalProfile()
	{
		// Enum dəyərləri int olaraq saxlanırsa bu şəkildə çevrilməlidir
		CreateMap<CreateAnimalDto, Animal>().ReverseMap()
			.ForMember(dest => dest.Gender, opt => opt.MapFrom(src => (Gender)src.Gender));

		CreateMap<UpdateAnimalDto, Animal>().ReverseMap();

		CreateMap<GetAllAnimalDto, Animal>().ReverseMap()
			.ForMember(dest => dest.Gender, opt => opt.MapFrom(src => (Gender)src.Gender));
	}
}



