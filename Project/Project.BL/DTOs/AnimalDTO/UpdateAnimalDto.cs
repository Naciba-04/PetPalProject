using FluentValidation;
using Microsoft.AspNetCore.Http;
using Project.BL.Utilities;
using Project.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs.AnimalDTO;

public class UpdateAnimalDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile CoverImage { get; set; }
    public string CoverImageUrl { get; set; }
    public decimal Weight { get; set; }
    public string Color { get; set; }
}
public class UpdateAnimalDtoValidation : AbstractValidator<UpdateAnimalDto>
{
    public UpdateAnimalDtoValidation()
    {
        RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage("title cannot be empty or null")
                .MaximumLength(255).WithMessage("the title must have a maximum of 255 characters");

        RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage("Description cannot be empty or null")
            .MaximumLength(255).WithMessage("the Description must have a maximum of 255 characters");

        RuleFor(x => x.Color).NotEmpty().NotNull().WithMessage("Color cannot be empty or null")
            .MaximumLength(64).WithMessage("the Color must have a maximum of 255 characters");

        RuleFor(x => x.Weight)
            .GreaterThan(0).WithMessage("Weight must be greater than 0.")
            .LessThanOrEqualTo(200).WithMessage("Weight cannot exceed 1000 kg.");

        RuleFor(x => x.CoverImage)
        .Cascade(CascadeMode.Stop)
        .NotNull().WithMessage("Image cannot be null!")
        .Must(x => x.Length <= 2 * 1024 * 1024).WithMessage("File size must be less than 2 MB!")
        .Must(x => x.CheckType("image")).WithMessage("File must be image!"); ;

    }
}
