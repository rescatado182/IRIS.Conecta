using IRIS.Frontend.Repositories;
using IRIS.UI.AuthenticationProviders;
using IRIS.UI.Models.List;
using IRIS.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Sockets;
using TabBlazor;

namespace IRIS.UI.Shared
{
    public partial class Header
    {
        private System.Security.Claims.ClaimsPrincipal user;

        private string userName;

        [Inject] private NavigationManager NavigationManager { get; set; } = null!;

        [Inject] public AuthenticationProviderJWT AuthenticationProviderJWT { get; set; }

        [Inject] private ILoginService LoginService { get; set; } = null!;
        [CascadingParameter] private Task<AuthenticationState> AuthenticationStateTask { get; set; } = null!;
        public string userId = string.Empty;

        public GetUserByUserIdVM userData { get; set; } = null!;

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

            userId = await AuthenticationProviderJWT.GetUserIdAsync();
            await GetNameUser();
        }


        [Inject] private IRepository Repository { get; set; } = null!;

        private async Task<bool> GetNameUser()
        {
            var responseHttp = await Repository.GetAsync<GetUserByUserIdVM>($"/api/Users/GetUserByUserId/{userId}");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                return false;
            }
            userData = responseHttp.Response;
            return true;
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