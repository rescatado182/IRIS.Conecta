using Microsoft.AspNetCore.Components.Authorization;

namespace IRIS.UI.Services
{
    public interface ILoginService
    {
        Task<AuthenticationState> GetAuthenticationStateAsync();
        Task LoginAsync(string token);

        Task LogoutAsync();
    }
}
