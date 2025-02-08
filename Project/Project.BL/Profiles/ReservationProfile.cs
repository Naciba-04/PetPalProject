using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Project.BL.DTOs.ReservationDTO;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Profiles;

public class ReservationProfile:Profile
{
    public ReservationProfile()
    {
        CreateMap<GetAllReservationDto, Reservation>().ReverseMap()
            .ForMember(dest => dest.PetServiceName, options => options.MapFrom(src => src.PetService.Name))
            .ForMember(dest => dest.PetTypeName, options => options.MapFrom(src => src.PetType.Name));
        CreateMap<UpdateReservationDto, Reservation>().ReverseMap();
        CreateMap<CreateReservationDto, Reservation>().ReverseMap();

    }
}
