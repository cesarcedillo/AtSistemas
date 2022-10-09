namespace AtSistemas.Identity.Persistence;

using Microsoft.EntityFrameworkCore;
using AtSistemas.Identity.Models;
using Microsoft.Extensions.Configuration;

public class AtSistemasIdentityDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    private readonly IConfiguration Configuration;

    public AtSistemasIdentityDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseInMemoryDatabase("AtSistemasIdentity");
    }
}
