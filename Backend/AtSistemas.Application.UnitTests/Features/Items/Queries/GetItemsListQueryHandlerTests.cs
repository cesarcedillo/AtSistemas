using AtSistemas.Application.Features.Items.Queries;
using AtSistemas.Application.Features.Items.Queries.GetItemsList;
using AtSistemas.Application.Mappings;
using AtSistemas.Application.UnitTests.Mocks;
using AtSistemas.Infrastructure.Repositories;
using AutoMapper;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Features.Items.Queries
{
    public class GetItemsListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetItemsListQueryHandlerTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(configuration => 
            {
                configuration.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetItemsListQuery_ReturnsItemsList()
        {
            var handler = new GetItemsListQueryHandler(_unitOfWork.Object, _mapper);
            var request = new GetItemsListQuery();

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<List<ItemsVm>>();
        }
    }
}
