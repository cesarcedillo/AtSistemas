using AtSistemas.Application.Features.Items.Queries;
using AtSistemas.Application.Features.Items.Queries.GetItemById;
using AtSistemas.Application.Features.Items.Queries.GetItemsList;
using AtSistemas.Application.Mappings;
using AtSistemas.Application.UnitTests.Constants;
using AtSistemas.Application.UnitTests.Mocks;
using AtSistemas.Infrastructure.Repositories;
using AutoMapper;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Features.Items.Queries
{
    public class GetItemByIdQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetItemByIdQueryHandlerTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(configuration => 
            {
                configuration.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetItemByIdQuery_InputItem_ReturnsItem()
        {
            var handler = new GetItemByIdQueryHandler(_unitOfWork.Object, _mapper);
            var request = new GetItemByIdQuery(InitialValues.Item.Id);

            var result = await handler.Handle(request, CancellationToken.None);

            result.Name.ShouldBe(InitialValues.Item.Name);
        }
    }
}
