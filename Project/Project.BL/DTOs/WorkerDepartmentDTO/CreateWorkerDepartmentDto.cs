using FluentValidation;
using Project.BL.DTOs.DepartmentDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs.WorkerDepartmentDTO;

public class CreateWorkerDepartmentDto
{
    public string Name { get; set; }

}
public class CreateWorkerDepartmentDtoValidation : AbstractValidator<CreateWorkerDepartmentDto>
{
    public CreateWorkerDepartmentDtoValidation()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("name cannot be empty or null")
            .MaximumLength(64).WithMessage("the name must have a maximum of 64 characters");

    }
}
