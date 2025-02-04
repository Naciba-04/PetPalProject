using AutoMapper;
using Project.BL.DTOs.DepartmentDTO;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Profiles;

public class DepartmentProfile : Profile
{
    public DepartmentProfile()
    {
        CreateMap<CreateDepartmentDto, Department>().ReverseMap();
        CreateMap<UpdateDepartmentDto, Department>().ReverseMap();
        CreateMap<GetAllDepartmentDto, Department>().ReverseMap();
    }
}