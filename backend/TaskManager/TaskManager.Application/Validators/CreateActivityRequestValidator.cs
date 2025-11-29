using FluentValidation;
using TaskManager.Application.DTO.Request;

namespace TaskManager.Application.Validators
{
    public class CreateActivityRequestValidator : AbstractValidator<CreateActivityRequest>
    {
        public CreateActivityRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title can't be empty!")
                .MaximumLength(50).WithMessage("Title must be less then 50 characters");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description must be less then 1000 characters")
                .When(a => a.Description is not null);

            RuleFor(x => x.Priority)
                .IsInEnum().WithMessage("Invalid value.");

            RuleFor(x => x.ProjectId)
                .GreaterThan(0).WithMessage("Invalid ID.");

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("Invalid ID.");

        }
    }
}
