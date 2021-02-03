using FluentValidation;

namespace XSSFilterEvasion.Api.Features
{
    public class ToDoValidator : AbstractValidator<ToDoDto>
    {
        public ToDoValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();
        }
    }
}
