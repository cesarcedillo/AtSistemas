using AtSistemas.Application.UnitTests.Constants;
using AtSistemas.Domain;
using AtSistemas.Infrastructure.Persistence;
using AtSistemas.Infrastructure.Repositories;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;

namespace AtSistemas.Application.UnitTests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            var dbContextId = Guid.NewGuid();

            var options = new DbContextOptionsBuilder<InventaryDbContext>()
                .UseInMemoryDatabase(databaseName: $"InventaryDbContext-{dbContextId}")
                .Options;

            var inventaryDbContextFake = new InventaryDbContext(options);

            inventaryDbContextFake.Database.EnsureDeleted();

            var mockUnitOfWork = new Mock<UnitOfWork>(inventaryDbContextFake);

            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var items = fixture.CreateMany<Item>().ToList();
            items.Add(fixture.Build<Item>()
                .With(item => item.Id, InitialValues.Item.Id)
                .With(item => item.Name, InitialValues.Item.Name)
                .Create());

            inventaryDbContextFake.Items!.AddRange(items);
            inventaryDbContextFake.SaveChanges();


            return mockUnitOfWork;
        }
    }
}
