using AtSistemas.Domain;

namespace AtSistemas.Application.UnitTests.Constants
{
    public static class InitialValues
    {
        public static Item Item { get; set; } = new Item {
            Id = "b35225cf-343b-40f7-a8d5-dfdd23a1261a",
            Name = "Item test",
            Type = "Item type test",
            ExpirationDate = new DateTime(2030, 1, 1)
        };
    }
}
