using AutoMapper;
using AtSistemas.Application.Contracts.Persistence;
using MediatR;
using AtSistemas.Domain;

namespace AtSistemas.Application.Features.Items.Queries.GetItemById
{
    public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, ItemsVm>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetItemByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ItemsVm> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var itemRepository = _unitOfWork.Repository<Item>();

            var itemList = await itemRepository.GetByIdAsync(request.Id!);

            return _mapper.Map<ItemsVm>(itemList);
        }
    }
}
