namespace AtSistemas.Domain.Common
{
    public abstract class BaseDomainModel
    {
        public string Id { get; set; } = string.Empty;
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
