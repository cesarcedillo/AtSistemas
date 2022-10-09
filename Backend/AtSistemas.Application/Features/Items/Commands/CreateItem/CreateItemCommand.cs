using MediatR;

namespace AtSistemas.Application.Features.Items.Commands.CreateItem
{
    public class CreateItemCommand : IRequest<string>
    {
        public string Name { get; set; } = String.Empty;
        public DateTime ExpirationDate { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}
