using AtSistemas.Application.Models.Identity;

namespace AtSistemas.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);

        Task<RegistrationResponse> Register(RegistrationRequest request);

        Task Populate();
    }
}
