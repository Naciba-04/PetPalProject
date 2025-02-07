using AutoMapper;
using Project.BL.DTOs.PetServiceDTO;
using Project.BL.DTOs.PetTypeDTO;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Profiles;

public class PetTypeProfile:Profile
{
    public PetTypeProfile()
    {
        CreateMap<GetAllPetTypeDto, PetType>().ReverseMap();
        CreateMap<CreatePetTypeDto, PetType>().ReverseMap();
        CreateMap<UpdatePetTypeDto, PetType>().ReverseMap();
    }
}
