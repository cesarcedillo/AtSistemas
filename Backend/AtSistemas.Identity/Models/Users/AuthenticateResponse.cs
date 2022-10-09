namespace AtSistemas.Identity.Models.Users;

using AtSistemas.Identity.Models;

public class AuthenticateResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string Username { get; set; } = String.Empty;
    public Role Role { get; set; }
    public string Token { get; set; } = String.Empty;

    public AuthenticateResponse(User user, string token)
    {
        Id = user.Id;
        FirstName = user.FirstName;
        LastName = user.LastName;
        Username = user.Username;
        Role = user.Role;
        Token = token;
    }
}
