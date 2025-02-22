using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs.WorkerDepartmentDTO;

public class GetAllWorkerDepartmentDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Department Department { get; set; }
}
