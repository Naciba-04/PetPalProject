using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs.WorkerDTO;

public class GetAllWorkerDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string ProfileImageUrl { get; set; }
    public string DepartmentName { get; set; }
}
