using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

namespace Project.BL.DTOs.ReservationDTO;

public class CreateReservationDto
{
    
    [Display(Prompt ="FullName")]
    public string FullName { get; set; }
    [Display(Prompt = "PetType")]
    public int PetTypeId { get; set; }
    [Display(Prompt = "PetService")]
    public int PetServiceId { get; set; }
    [Display(Prompt = "Date")]
    public DateTime Date { get; set; }
    [Display(Prompt = "StartTime")]
    public TimeSpan StartTime { get; set; }
    [Display(Prompt = "EndTime")]
    public TimeSpan EndTime { get; set; }
    [Display(Prompt = "Email")]
    public string Email { get; set; }

}

public class CreateReservationDtoValidator : AbstractValidator<CreateReservationDto>
{
    public CreateReservationDtoValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full Name is required")
            .MinimumLength(3).WithMessage("Full Name must be at least 3 characters long")
            .MaximumLength(100).WithMessage("Full Name cannot be longer than 100 characters");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");
    }
}


