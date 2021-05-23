using FluentValidation;

namespace Baram.Application.Departments.Commands
{
    public class InsertDepartmentCommandValidator : AbstractValidator<InsertDepartmentCommand>
    {
        public InsertDepartmentCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Department name is required.");
        }
    }
}
