using Project.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs.ReservationDTO;

public class UpdateReservationDto
{
    public int Id { get; set; }
    public ReservStatus ReservStatus { get; set; }
}
