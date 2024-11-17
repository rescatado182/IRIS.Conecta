using DocumentFormat.OpenXml.Spreadsheet;
using IRIS.Frontend.Repositories;
using IRIS.UI.AuthenticationProviders;
using IRIS.UI.Icons;
using IRIS.UI.Models.List;
using IRIS.UI.Pages.BL.Actions;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using TabBlazor;
using TabBlazor.Services;

namespace IRIS.UI.Pages.BL.Tickets.SearchTickets
{
    public partial class SearchTicket
    {
        [Inject] public AuthenticationProviderJWT AuthenticationProviderJWT { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] TablerService TablerService { get; set; }

        [Inject] IJSRuntime JSRuntime { get; set; }       
        [Inject] IModalService ModalService { get; set; }        
        [Inject] private IRepository Repository { get; set; } = null!;

        private static List<TicketManageListVM> selectedOrders = new List<TicketManageListVM>();
        public List<TicketManageListVM>? tickets { get; set; }
        public List<ManagersListVM> managers { get; set; }
        public string userId;

        [Parameter] public int ticketId { get; set; }

        public GetTicketbyIdVM ticket { get; set; } = null!;



        protected override async Task OnInitializedAsync()
        {
            userId = await AuthenticationProviderJWT.GetUserIdAsync();
            await ListAsync();

        }

        private async Task<bool> ListAsync()
        {
            var responseHttp = await Repository.GetAsync<List<TicketManageListVM>>($"/api/Tickets/Getticketsbyuser/{userId}");

            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                return false;
            }

            tickets = responseHttp.Response;

            if (!await GetListManagersAsync())
                return false;


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

        private async Task<bool> GetListManagersAsync()
        {
            var responseHttp = await Repository.GetAsync<List<ManagersListVM>>("/api/Users/GetManagers");

            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                return false;
            }

            managers = responseHttp.Response;

            return true;
        }


        private async Task SendNotificationTicket()
        {
            // Define the component `ChangeStatus` and configure its properties
            var component = new RenderComponent<EscalateTicket>()
                .Set(e => e.ticketId, ticketId)
                .Set<string>(e => e.userId, ticket.UserId)
                .Set<string>(e => e.CurrentStatus, ticket.Status)
                .Set<string>(e => e.ManagerUserId, ticket.ManagerUserId);

            var result = await ModalService.ShowAsync("Escalar la Solicitud", component, new ModalOptions { Size = ModalSize.Medium });


        }

        private async Task ChangeStatusTicket()
        {


            var component = new RenderComponent<ChangeStatus>()
                .Set<string>(e => e.CurrentStatus, ticket.Status)
                .Set(e => e.ticketId, ticketId)
                .Set<string>(e => e.userId, ticket.UserId)
                .Set<string>(e => e.ManagerUserId, ticket.ManagerUserId);

            var result = await ModalService.ShowAsync("Cambiar Estado de la Solicitud", component, new ModalOptions { Size = ModalSize.Medium });




        }

        private async Task ShowDialog(string title)
        {
            await ModalService.ShowDialogAsync(new TabBlazor.Components.Modals.DialogOptions
            {
                CancelText = "",
                StatusColor = TablerColor.Primary,
                IconType = @TablerIcons.Info_circle,
                MainText = title
            });
        }


    }
}