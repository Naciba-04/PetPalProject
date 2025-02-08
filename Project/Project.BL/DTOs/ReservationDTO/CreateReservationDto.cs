using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

namespace Project.BL.DTOs.ReservationDTO;

public class CreateReservationDto
{
    [Required]
    [Display(Prompt ="FullName")]
    
    public string FullName { get; set; }
    [Required]
    [Display(Prompt = "PetType")]
    public int PetTypeId { get; set; }
    [Required]
    [Display(Prompt = "PetService")]
    public int PetServiceId { get; set; }
    [Required]
    [Display(Prompt = "Date")]
    public DateTime Date { get; set; }
    [Required]
    [Display(Prompt = "StartTime")]
    public TimeSpan StartTime { get; set; }
    [Required]
    [Display(Prompt = "EndTime")]
    public TimeSpan EndTime { get; set; }
    [Required]
    [Display(Prompt = "Email")]
    [EmailAddress]
    public string Email { get; set; }

}

