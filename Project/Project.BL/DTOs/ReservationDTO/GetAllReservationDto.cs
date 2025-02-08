using Project.Core.Enums;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs.ReservationDTO;

public class GetAllReservationDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public int PetTypeId { get; set; }
    public string PetTypeName { get; set; }
    public int PetServiceId { get; set; }
    public string PetServiceName { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string Email { get; set; }
    public ReservStatus ReservStatus { get; set; } 
}

