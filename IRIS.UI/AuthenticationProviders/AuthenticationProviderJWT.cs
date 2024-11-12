using IRIS.UI.Helpers;
using IRIS.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace IRIS.UI.AuthenticationProviders
{
    public class AuthenticationProviderJWT : AuthenticationStateProvider, ILoginService
    {
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        private readonly IJSRuntime _jSRuntime;
        private readonly HttpClient _httpClient;
        private readonly string _tokenKey;
        private readonly AuthenticationState _anonimous;

        public AuthenticationProviderJWT(IJSRuntime jSRuntime, HttpClient httpClient)
        {
            _jSRuntime = jSRuntime;
            _httpClient = httpClient;
            _tokenKey = "TOKEN_KEY";
            _anonimous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _jSRuntime.GetLocalStorage(_tokenKey);
             if (token is null)
            {
                return _anonimous;
            }

            return BuildAuthenticationState(token.ToString()!);
        }

        public async Task LoginAsync(string token)
        {
            await _jSRuntime.SetLocalStorage(_tokenKey, token);
            var authState = BuildAuthenticationState(token);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));

        }

        public async Task LogoutAsync()
        {
            await _jSRuntime.RemoveLocalStorage(_tokenKey);
            _httpClient.DefaultRequestHeaders.Authorization = null;
            NotifyAuthenticationStateChanged(Task.FromResult(_anonimous));
        }

        private string GetUserNameFromClaims(IEnumerable<Claim> claims)
        {
            // Asume que tienes un claim con el nombre del usuario
            var nameClaim = claims.FirstOrDefault(c => c.Type == "sub");

            return nameClaim?.Value ?? "Usuario";
        }

        private AuthenticationState BuildAuthenticationState(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var claims = ParseClaimsFromJWT(token);
            var userName = GetUserNameFromClaims(claims);

            claims = claims.Append(new Claim(ClaimTypes.Name, userName));

            // Guardamos el nombre de usuario en el estado
            var identity = new ClaimsIdentity(claims, "jwt"); 
            var principal = new ClaimsPrincipal(identity);
            return new AuthenticationState(principal);
        }

        private IEnumerable<Claim> ParseClaimsFromJWT(string token)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var unserializedToken = jwtSecurityTokenHandler.ReadJwtToken(token);
            return unserializedToken.Claims;
        }


    }
}
