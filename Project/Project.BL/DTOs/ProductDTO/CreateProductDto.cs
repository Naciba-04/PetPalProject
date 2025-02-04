using FluentValidation;
using Microsoft.AspNetCore.Http;
using Project.BL.Utilities;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs.ProductDTO;

public class CreateProductDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile CoverImage { get; set; }
    public int Quantity { get; set; }
    public decimal OldPrice { get; set; }
    public int Discount { get; set; }
    public int DepartmentId { get; set; }
    
}
public class CreateProductDtoValidation : AbstractValidator<CreateProductDto>
{
    public CreateProductDtoValidation()
    {
        RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage("title cannot be empty or null")
                .MaximumLength(255).WithMessage("the title must have a maximum of 255 characters");

        RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage("Description cannot be empty or null")
            .MaximumLength(255).WithMessage("the Description must have a maximum of 255 characters");
            
        RuleFor(x => x.OldPrice).NotEmpty().NotNull().WithMessage("OldPrice cannot be empty or null")
           .GreaterThan(0).WithMessage("oldprice starts from 0");

        RuleFor(x => x.CoverImage)
        .Cascade(CascadeMode.Stop)
        .NotNull().WithMessage("Image cannot be null!")
        .Must(x => x.Length <= 2 * 1024 * 1024).WithMessage("File size must be less than 2 MB!")
        .Must(x => x.CheckType("image")).WithMessage("File must be image!"); ;

        RuleFor(x => x.Discount)
            .InclusiveBetween(0, 100).WithMessage("Discount must be between 0 and 100.");

        RuleFor(x => x.Quantity)
            .InclusiveBetween(1, 1000).WithMessage("Quantity must be between 1 and 1000.");


    }
}
