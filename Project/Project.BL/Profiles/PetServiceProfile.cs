using AutoMapper;
using Project.BL.DTOs.PetServiceDTO;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Profiles;

public class PetServiceProfile:Profile
{
    public PetServiceProfile()
    {
        CreateMap<GetAllPetServiceDto, PetService>().ReverseMap();
        CreateMap<CreatePetServiceDto, PetService>().ReverseMap();
        CreateMap<UpdatePetServiceDto, PetService>().ReverseMap();
    }
}
