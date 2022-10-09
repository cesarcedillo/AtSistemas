using AutoMapper;
using AtSistemas.Application.Contracts.Persistence;
using MediatR;
using AtSistemas.Domain;

namespace AtSistemas.Application.Features.Items.Queries.GetItemsList
{
    public class GetItemsListQueryHandler : IRequestHandler<GetItemsListQuery, List<ItemsVm>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetItemsListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ItemsVm>> Handle(GetItemsListQuery request, CancellationToken cancellationToken)
        {
            var itemRepository = _unitOfWork.Repository<Item>();

            var itemList = await itemRepository.GetAllAsync();

            return _mapper.Map<List<ItemsVm>>(itemList);
        }
    }
}
