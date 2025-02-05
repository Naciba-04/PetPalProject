using AutoMapper;
using Project.BL.DTOs.RatingDTO;
using Project.BL.Services.Abstraction;
using Project.Core.Model;
using Project.DAL.Repository.Abstaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Implementation;

public class RatingService(IGenericRepository<Rating> _ratingRepository,IMapper _mapper):IRatingService
{
    public async Task<ICollection<GetAllRatingCommentDto>> GetAllAsync()
    {
        var res = await _ratingRepository.GetAllAsync("AppUser");
        return _mapper.Map<ICollection<GetAllRatingCommentDto>>(res);
    }
}
