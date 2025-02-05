using Project.Core.Enums;
using Project.Core.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Model;

public class Reservation : BaseEntity
{
    public string FullName { get; set; }
    public int PetTypeId { get; set; }
    public PetType PetType { get; set; }
    public int PetServiceId { get; set; }
    public PetService PetService { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string Email { get; set; }
    public ReservStatus ReservStatus { get; set; } = ReservStatus.Pending;

}
