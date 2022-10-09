using FluentValidation;

namespace AtSistemas.Application.Features.Items.Queries.GetItemById
{
    public class GetItemByIdQueryValidator : AbstractValidator<GetItemByIdQuery>
    {
        public GetItemByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("{Id} can not be empty")
                .NotNull().WithMessage("{Id} can not be null");
        }
    }
}
