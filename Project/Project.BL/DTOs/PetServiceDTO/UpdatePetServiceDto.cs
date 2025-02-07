using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs.PetServiceDTO;

public class UpdatePetServiceDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class UpdatePetServiceDtoValidation : AbstractValidator<UpdatePetServiceDto>
{
    public UpdatePetServiceDtoValidation()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("name cannot be empty or null")
            .MaximumLength(64).WithMessage("the name must have a maximum of 64 characters");
    }
}
