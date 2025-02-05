using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs.RatingDTO;

public class CreateRatingCommentDto
{
    public int Score { get; set; }
    public string? Comment { get; set; }
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
}
