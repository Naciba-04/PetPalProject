using Project.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs.AdoptionDTO;

public class UpdateAdoptionDto
{
    public int Id { get; set; }
    public ReservStatus ReservStatus { get; set; }
}
