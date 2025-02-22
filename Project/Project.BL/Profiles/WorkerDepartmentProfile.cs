using AutoMapper;
using Project.BL.DTOs.DepartmentDTO;
using Project.BL.DTOs.WorkerDepartmentDTO;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Profiles;

public class WorkerDepartmentProfile:Profile
{
    public WorkerDepartmentProfile()
    {
        CreateMap<CreateWorkerDepartmentDto, WorkerDepartment>().ReverseMap();
        CreateMap<UpdateWorkerDepartmentDto, WorkerDepartment>().ReverseMap();
        CreateMap<GetAllWorkerDepartmentDto, WorkerDepartment>().ReverseMap();
    }
}
