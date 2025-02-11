using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs.AdoptionDTO;

public class CreateAdoptionDto
{
    public string FullName { get; set; }
    public bool HasHouse { get; set; }
    public string Email { get; set; }
    public decimal Salary { get; set; }
}

public class CreateAdoptionDtoValidator : AbstractValidator<CreateAdoptionDto>
{
    public CreateAdoptionDtoValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full Name is required")
            .MinimumLength(3).WithMessage("Full Name must be at least 3 characters long")
            .MaximumLength(100).WithMessage("Full Name cannot be longer than 100 characters");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");

        RuleFor(x => x.Salary)
            .GreaterThan(0).WithMessage("Salary must be greater than 0")
            .LessThanOrEqualTo(1000000).WithMessage("Salary cannot exceed 1,000,000");

        RuleFor(x => x.HasHouse)
            .NotNull().WithMessage("HasHouse field is required");
    }
}
