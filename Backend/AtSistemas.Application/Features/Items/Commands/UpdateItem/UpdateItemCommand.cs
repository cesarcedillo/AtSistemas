using MediatR;

namespace AtSistemas.Application.Features.Items.Commands.UpdateItem
{
    public class UpdateItemCommand : IRequest
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = String.Empty;
        public DateTime ExpirationDate { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}
