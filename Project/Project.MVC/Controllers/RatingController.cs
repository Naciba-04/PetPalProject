using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Core.Model;
using Project.DAL.Contexts;
using Project.DAL.Repository.Abstaction;
using System;

namespace Project.MVC.Controllers;

public class RatingController(PetPatFinalProjectDbContext _context, UserManager<AppUser> _userManager, IGenericRepository<Rating> _repository) : Controller
{
    public IActionResult SubmitRating()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SubmitRating(int score, string? comment)
    {

        var user = await _userManager.GetUserAsync(User);
        if (user == null) return RedirectToAction("Message", "Rating");

        var existingRating = await _context.Ratings.FirstOrDefaultAsync(r => r.AppUserId == user.Id);
        if (existingRating != null)
        {
            return BadRequest("Siz artıq reyting vermisiniz.");
        }

        var rating = new Rating
        {
            Score = score,
            Comment = comment,
            AppUserId = user.Id
        };

        await _context.Ratings.AddAsync(rating);
        await _context.SaveChangesAsync();

        return RedirectToAction("CommentDetails", "Pages");
    }
    public IActionResult Message()
    {
        return View();
    }
}
