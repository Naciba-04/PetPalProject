using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs.PetTypeDTO;

public class UpdatePetTypeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class UpdatePetTypeDtoValidation : AbstractValidator<UpdatePetTypeDto>
{
    public UpdatePetTypeDtoValidation()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("name cannot be empty or null")
            .MaximumLength(64).WithMessage("the name must have a maximum of 64 characters");
    }
}
