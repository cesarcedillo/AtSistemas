using MediatR;

namespace AtSistemas.Application.Features.Items.Queries.GetItemsList
{
    public class GetItemsListQuery : IRequest<List<ItemsVm>>
    {
    }
}
