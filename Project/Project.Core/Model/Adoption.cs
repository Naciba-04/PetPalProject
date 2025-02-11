using Project.Core.Enums;
using Project.Core.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Model;

public class Adoption : BaseEntity
{
    public string FullName { get; set; }
    public bool HasHouse { get; set; }
    public string Email { get; set; }
    public decimal Salary { get; set; }
    public ReservStatus ReservStatus { get; set; } = ReservStatus.Pending;
}
