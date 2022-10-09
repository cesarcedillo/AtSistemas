using MediatR;

namespace AtSistemas.Application.Features.Items.Queries.GetItemById
{
    public class GetItemByIdQuery : IRequest<ItemsVm>
    {
        public string? Id { get; set; }

        public GetItemByIdQuery(string id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }
    }
}
