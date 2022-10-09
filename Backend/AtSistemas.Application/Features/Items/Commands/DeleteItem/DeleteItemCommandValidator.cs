using FluentValidation;

namespace AtSistemas.Application.Features.Items.Commands.DeleteItem
{
    public class DeleteItemCommandValidator : AbstractValidator<DeleteItemCommand>
    {
        public DeleteItemCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("{Id} can not be empty")
                .NotNull().WithMessage("{Id} can not be null");
        }
    }
}
