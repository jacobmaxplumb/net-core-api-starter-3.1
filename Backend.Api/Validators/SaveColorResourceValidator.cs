using FluentValidation;
using Backend.Api.Resources;

namespace Backend.Api.Validations
{
    public class SaveColorResourceValidator : AbstractValidator<SaveColorResource>
    {
        public SaveColorResourceValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}