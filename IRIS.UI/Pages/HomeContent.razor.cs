using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Spreadsheet;
using IRIS.Frontend.Repositories;
using IRIS.UI.AuthenticationProviders;
using IRIS.UI.Models.List;
using IRIS.UI.Services;
using Microsoft.AspNetCore.Components;

namespace IRIS.UI.Pages
{
    public partial class HomeContent
    {
        [Inject] public AuthenticationProviderJWT AuthenticationProviderJWT { get; set; }

        [Inject] private ILoginService LoginService { get; set; } = null!;

        [Inject] private IRepository Repository { get; set; } = null!;

        public List<ManagersListVM> managers { get; set; }

        private System.Security.Claims.ClaimsPrincipal user;

        private string userName;
        public string userId = string.Empty;

        public GetUserByUserIdVM userData { get; set; } = null!;

        public List<TicketManageListVM>? tickets { get; set; }

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
            await ListAsync();
        }



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

        private async Task<bool> ListAsync()
        {
            var responseHttp = await Repository.GetAsync<List<TicketManageListVM>>("/api/Tickets");

            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                return false;
            }

            // Asignar los tickets obtenidos
            var allTickets = responseHttp.Response;

            // Filtrar los tickets donde ManagerUserId sea igual a userId
            tickets = allTickets?.Where(ticket => ticket.ManagerUserId == userId).ToList();

            return true;



            foreach (var ticket in tickets)
            {
                var manager = managers.FirstOrDefault(m => m.Id == ticket.ManagerUserId);
                if (manager != null)
                {
                    ticket.ManagerName = manager.FullName;
                }
            }

            return true;
        }
    }
}
