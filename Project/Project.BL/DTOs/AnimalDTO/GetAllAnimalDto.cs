using Project.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs.AnimalDTO;

public class GetAllAnimalDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string CoverImageUrl { get; set; }
    public decimal Weight { get; set; }
    public string Color { get; set; }
    public string Gender { get; set; }
}
