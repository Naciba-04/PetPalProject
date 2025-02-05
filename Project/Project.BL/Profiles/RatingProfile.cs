using AutoMapper;
using Project.BL.DTOs.RatingDTO;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Profiles;

public class RatingProfile:Profile
{
    public RatingProfile()
    {
        CreateMap<GetAllRatingCommentDto, Rating>().ReverseMap()
            .ForMember(dest => dest.AppUserName, options => options.MapFrom(src => src.AppUser.UserName))
            .ForMember(dest => dest.AppFullName, options => options.MapFrom(src => src.AppUser.FullName));
        CreateMap<CreateRatingCommentDto, Rating>().ReverseMap();
    }
}
