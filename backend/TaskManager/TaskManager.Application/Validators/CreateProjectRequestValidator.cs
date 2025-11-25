using FluentValidation;
using TaskManager.Application.DTO.Request;

namespace TaskManager.Application.Validators
{
    public class CreateProjectRequestValidator : AbstractValidator<CreateProjectRequest>
    {
        public CreateProjectRequestValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MinimumLength(3).WithMessage("Name length must be at least 3.")
            .MaximumLength(100).WithMessage("Name length must be lower then 100");

            RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description must have less then 500 characters")
            .When(p => p.Description is not null)
                .WithMessage("The project description must not exceed 500 characters."); ;
        }
    }
}
