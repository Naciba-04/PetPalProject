using AutoMapper;
using Project.BL.DTOs.AdoptionDTO;
using Project.BL.DTOs.ReservationDTO;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Profiles;

public class AdoptionProfile:Profile
{
    public AdoptionProfile()
    {
        CreateMap<GetAllAdoptionDto, Adoption>().ReverseMap();
        CreateMap<UpdateAdoptionDto, Adoption>().ReverseMap();
        CreateMap<CreateAdoptionDto, Adoption>().ReverseMap();
    }
}
