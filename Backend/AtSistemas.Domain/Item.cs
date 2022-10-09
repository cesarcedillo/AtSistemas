using AtSistemas.Domain.Common;

namespace AtSistemas.Domain
{
    public class Item : BaseDomainModel
    {
        public string? Name { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? Type { get; set; }
    }
}