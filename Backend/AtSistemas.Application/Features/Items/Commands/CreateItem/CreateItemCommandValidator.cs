using FluentValidation;

namespace AtSistemas.Application.Features.Items.Commands.CreateItem
{
    public class DeleteItemCommandValidator : AbstractValidator<CreateItemCommand>
    {
        public DeleteItemCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{Name} can not be empty")
                .NotNull().WithMessage("{Name} can not be null")
                .MaximumLength(50).WithMessage("{Name} can not have length more than 50 characters");

            RuleFor(x => x.ExpirationDate)
                .NotEmpty().WithMessage("{ExpirationDate} can not be empty")
                .NotNull().WithMessage("{ExpirationDate} can not be null");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("{Type} can not be empty")
                .NotNull().WithMessage("{Type} can not be null")
                .MaximumLength(50).WithMessage("{Type} can not have length more than 50 characters");
        }
    }
}
