using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs.DepartmentDTO;

public class GetAllDepartmentDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Department Department { get; set; }
}
