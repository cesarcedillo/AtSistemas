using AtSistemas.Domain;
using AtSistemas.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace AtSistemas.Infrastructure.Persistence
{
    public class InventaryDbContext : DbContext
    {
        public InventaryDbContext(DbContextOptions<InventaryDbContext> options): base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellation = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch(entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "system";
                        entry.Entity.Id = Guid.NewGuid().ToString();
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "system";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellation);
        }

        public DbSet<Item>? Items { get; set; }
    }
}