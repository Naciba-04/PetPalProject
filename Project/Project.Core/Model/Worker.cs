using Project.Core.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Model;

public class Worker:BaseEntity
{
    public string FullName { get; set; }
    public string ProfileImageUrl { get; set; }
    public int WorkerDepartmentId { get; set; }
    public WorkerDepartment WorkerDepartment { get; set; }
}
