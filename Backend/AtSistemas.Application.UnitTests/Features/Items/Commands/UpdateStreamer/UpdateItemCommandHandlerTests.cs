using AutoMapper;
using AtSistemas.Application.Mappings;
using AtSistemas.Application.UnitTests.Mocks;
using AtSistemas.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;
using AtSistemas.Application.Features.Items.Commands.UpdateItem;
using AtSistemas.Application.UnitTests.Constants;

namespace AtSistemas.Application.UnitTests.Features.Items.Commands.UpdateItem
{
    public class UpdateItemCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<UpdateItemCommandHandler>> _logger;

        public UpdateItemCommandHandlerTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _logger = new Mock<ILogger<UpdateItemCommandHandler>>();
        }

        [Fact]
        public async Task UpdateItemCommand_InputItem_ReturnsUnit()
        {
            var itemInput = new UpdateItemCommand
            {
                Id = InitialValues.Item.Id,
                Name = "Item test updated",
                Type = "Item type test updated",
                ExpirationDate = new DateTime(2040, 1, 1)
            };

            var handler = new UpdateItemCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
            var result = await handler.Handle(itemInput, CancellationToken.None);

            result.ShouldBeOfType<Unit>();
        }
    }
}
