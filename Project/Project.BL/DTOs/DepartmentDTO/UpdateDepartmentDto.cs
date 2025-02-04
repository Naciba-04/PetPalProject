using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs.DepartmentDTO;

public class UpdateDepartmentDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class UpdateDepartmentDtoValidation : AbstractValidator<UpdateDepartmentDto>
{
    public UpdateDepartmentDtoValidation()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("name cannot be empty or null")
            .MaximumLength(64).WithMessage("the name must have a maximum of 64 characters");
    }
}
