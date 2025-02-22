using FluentValidation;
using Microsoft.AspNetCore.Http;
using Project.BL.DTOs.ProductDTO;
using Project.BL.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs.WorkerDTO;

public class CreateWorkerDto
{
    public string FullName { get; set; }
    public IFormFile ProfileImage { get; set; }
    public int WorkerDepartmentId { get; set; }
}
public class CreateWorkerDtoValidation : AbstractValidator<CreateWorkerDto>
{
    public CreateWorkerDtoValidation()
    {
        RuleFor(x => x.FullName).NotEmpty().NotNull().WithMessage("fullname cannot be empty or null")
                .MaximumLength(128).WithMessage("the title must have a maximum of 128 characters");

        RuleFor(x => x.ProfileImage)
        .Cascade(CascadeMode.Stop)
        .NotNull().WithMessage("Image cannot be null!")
        .Must(x => x.Length <= 2 * 1024 * 1024).WithMessage("File size must be less than 2 MB!")
        .Must(x => x.CheckType("image")).WithMessage("File must be image!"); ;
    }
}

