using AutoMapper;
using Project.BL.DTOs.ProductDTO;
using Project.BL.DTOs.WorkerDTO;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Profiles;

public class WorkerProfile:Profile
{
    public WorkerProfile()
    {
        CreateMap<CreateWorkerDto, Worker>().ReverseMap();
        CreateMap<UpdateWorkerDto, Worker>().ReverseMap();
        CreateMap<GetAllWorkerDto, Worker>().ReverseMap()
               .ForMember(dest => dest.DepartmentName, options => options.MapFrom(src => src.WorkerDepartment.Name));

    }
}
