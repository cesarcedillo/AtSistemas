using System.Text.Json.Serialization;

namespace AtSistemas.Identity.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string Username { get; set; } = String.Empty;
    public Role Role { get; set; }

    [JsonIgnore]
    public string PasswordHash { get; set; } = String.Empty;
}
