using IRIS.UI.AuthenticationProviders;
using IRIS.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using TabBlazor;

namespace IRIS.UI.Shared
{
    public partial class Header
    {
        private System.Security.Claims.ClaimsPrincipal user;

        private string userName;

        [Inject] private NavigationManager NavigationManager { get; set; } = null!;

        [Inject] private ILoginService LoginService { get; set; } = null!;
        [CascadingParameter] private Task<AuthenticationState> AuthenticationStateTask { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            var authState = await LoginService.GetAuthenticationStateAsync();
            user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                // Asumimos que el nombre del usuario está en el claim "name"
                userName = user.Identity.Name ?? "Usuario";
                Console.WriteLine(userName);
            }

        }

        private void ShowProfileMenu()
        {
            // Aquí podrías mostrar un menú de perfil u opciones adicionales si lo deseas
            Console.WriteLine("Mostrar menú de perfil");
        }

        private async Task LogoutAsync()
        {

            await LoginService.LogoutAsync();
            NavigationManager.NavigateTo("/login", true);
        }

        private async Task LoginRedirectAsync()
        {
            await LoginService.LogoutAsync();
            NavigationManager.NavigateTo("/login");
        }
    }
}