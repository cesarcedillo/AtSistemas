using BCryptNet = BCrypt.Net.BCrypt;
using System.Text.Json.Serialization;
using AtSistemas.Identity.Authorization;
using AtSistemas.Identity.Models;
using AtSistemas.Infrastructure;
using AtSistemas.Application;
using AtSistemas.Identity.Persistence;
using AtSistemas.Identity;

var builder = WebApplication.CreateBuilder(args);

{
    var services = builder.Services;
    var env = builder.Environment;

    services.AddInfrastructureServices(builder.Configuration);
    services.AddApplicationServices();
    services.ConfigureIdentityServices(builder.Configuration);

    services.AddCors();
    services.AddControllers().AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
    services.AddSwaggerGen();
}

var app = builder.Build();

{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    app.UseMiddleware<JwtMiddleware>();

    app.MapControllers();
}

{
    var testUsers = new List<User>
    {
        new User { Id = 1, FirstName = "Admin", LastName = "User", Username = "admin", PasswordHash = BCryptNet.HashPassword("admin"), Role = Role.Admin },
        new User { Id = 2, FirstName = "Normal", LastName = "User", Username = "user", PasswordHash = BCryptNet.HashPassword("user"), Role = Role.User }
    };

    using var scope = app.Services.CreateScope();
    var dataContext = scope.ServiceProvider.GetRequiredService<AtSistemasIdentityDbContext>();
    dataContext.Users.AddRange(testUsers);
    dataContext.SaveChanges();
}

app.Run();

