using Project.BL.DTOs.RatingDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstraction;

public interface IRatingService
{
    Task<ICollection<GetAllRatingCommentDto>> GetAllAsync();

}
