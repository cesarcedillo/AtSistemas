using AtSistemas.Domain;
using MediatR;

namespace AtSistemas.Application.Features.Items.Commands.DeleteItem
{
    public class DeleteItemCommand : IRequest
    {
        public string Id { get; set; } = string.Empty;
    }
}
