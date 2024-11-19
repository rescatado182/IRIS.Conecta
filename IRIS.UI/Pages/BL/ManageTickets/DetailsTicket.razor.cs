using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using IRIS.Frontend.Repositories;
using IRIS.UI.Models;
using IRIS.UI.Models.List;
using IRIS.UI.Pages.BL.Actions;
using IRIS.UI.Pages.BL.Tickets.ResponseTickets;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using TabBlazor;
using TabBlazor.Services;
using Tabler.Docs;


namespace IRIS.UI.Pages.BL.ManageTickets
{
    public partial class DetailsTicket
    {
        [Inject] TablerService TablerService { get; set; }
        [Inject] private IRepository Repository { get; set; } = null!;

        [Inject] private IModalService ModalService { get; set; } = null!;

        [Inject] IOffcanvasService offcanvasService { get; set; }

        private string CurrentStatus;

        private bool IsActionPanelVisible { get; set; } = false;

        private void ToggleActionPanel()
        {
            IsActionPanelVisible = !IsActionPanelVisible;
        }

        private string statusText { get; set; } = null!;

        public List<ManagersListVM> managers { get; set; }
        public GetTicketbyIdVM ticket { get; set; } = null!;

        public PersonalDataDetailVM personalDataTicket { get; set; } = null!;

        public AcademyDataDetailVM academicDataTicket { get; set; } = null!;


        [Parameter] public int ticketId { get; set; }

        protected override async Task OnInitializedAsync()
        {

            await GetDetailTicket();
            await GetListPersonalDataTicketAsync();
            await GetListAcademicDataTicketAsync();

        }



        public async Task<bool> GetDetailTicket()
        {

            var responseHttp = await Repository.GetAsync<GetTicketbyIdVM>($"/api/Tickets/{ticketId}");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();


                return false;
            }

            ticket = responseHttp.Response;
            statusText = ticket.StatusDisplayName;

            if (!await GetListManagersAsync())
                return false;
            if (!await GetListUserNameAsync())
                return false;


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
            var manager = managers.FirstOrDefault(m => m.Id == ticket.ManagerUserId);
            if (manager != null)
            {
                ticket.ManagerUserName = manager.FullName;
            }

            return true;
        }

        private async Task<bool> GetListUserNameAsync()
        {
            var responseHttp = await Repository.GetAsync<GetUserByUserIdVM>($"/api/Users/GetUserByUserId/{ticket.UserId}");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                return false;
            }

            var user = responseHttp.Response;
            ticket.UserName = user.FullName;
            return true;
        }

        private async Task<bool> GetListPersonalDataTicketAsync()
        {
            var responseHttp = await Repository.GetAsync<PersonalDataDetailVM>($"/api/personaldata/{ticket.personalDataId}");
            if (responseHttp.Error || responseHttp.Response == null)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                return false;
            }

            personalDataTicket = responseHttp.Response;
            return true;
        }

        private async Task<bool> GetListAcademicDataTicketAsync()
        {
            var responseHttp = await Repository.GetAsync<AcademyDataDetailVM>($"/api/academicdata/{ticket.academicDataId}");


            if (responseHttp.Error || responseHttp.Response == null)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                return false;
            }

            academicDataTicket = responseHttp.Response;
            return true;
        }




        private TabBlazor.OffcanvasOptions options = new()
        {
            WrapperCssClass = "test-class",
            CloseOnEsc = true,
            CloseOnClickOutside = true,
            Position = TabBlazor.OffcanvasPosition.End
        };

        private async Task RefreshTicketDetails()
        {
            await GetDetailTicket();
        }

        private async Task SendNotificationTicket()
        {
            // Define the component `CreateComments` and configure its properties
            var component = new RenderComponent<SendNotificator>()
                .Set(e => e.OnSubmit, EventCallback.Factory.Create<string>(this, SubmitCommentAsync));

            // Open the Offcanvas with the comment form
            await offcanvasService.ShowAsync("Comentario para el Ticket", component, options);
        }

        public TablerColor GetTicketStatusColor()
        {
            return ticket.Status.ToLower() switch
            {
                "open" => TablerColor.Red,
                "inprocess" => TablerColor.Purple,
                "cancelled" => TablerColor.Orange,
                "closed" => TablerColor.Green,
                "resolved" => TablerColor.Yellow,
                _ => TablerColor.Pink
            };
        }


        private async Task EscalateTicket()
        {
            // Define the component `ChangeStatus` and configure its properties
            var component = new RenderComponent<EscalateTicket>()
                .Set(e => e.ticketId, ticketId)
                .Set<string>(e => e.userId, ticket.UserId)
                .Set<string>(e => e.CurrentStatus, ticket.Status)
                .Set<string>(e => e.ManagerUserId, ticket.ManagerUserId)
                .Set(e => e.OnClose, EventCallback.Factory.Create(this, RefreshTicketDetails));

            var result = await ModalService.ShowAsync("Escalar la Solicitud", component, new ModalOptions { Size = ModalSize.Medium });


        }

        private async Task TrackingTicket()
        {
            // Define the component `ChangeStatus` and configure its properties
            var component = new RenderComponent<ViewTrackingTicket>()
            .Set(e => e.ticketId, ticketId);
            //.Set<string>(e => e.userId, ticket.UserId)
            //.Set<string>(e => e.CurrentStatus, ticket.Status)
            //.Set<string>(e => e.ManagerUserId, ticket.ManagerUserId)
            //.Set(e => e.OnClose, EventCallback.Factory.Create(this, RefreshTicketDetails));

            var result = await ModalService.ShowAsync("Tracking Solicitud", component, new ModalOptions { Size = ModalSize.Medium });


        }

        private async Task SimilarAnswer()
        {
            // Define the component `ChangeStatus` and configure its properties
            var component = new RenderComponent<SimilarAnswerTicket>()
            .Set(e => e.tipo_movilidad, ticket.MovilityTypeDisplayName)
            .Set(e => e.Query, ticket.Busqueda);


            var result = await ModalService.ShowAsync("Solicitudes Similares", component, new ModalOptions { Size = ModalSize.XLarge });


        }

        private async Task ChangeStatusTicket()
        {


            var component = new RenderComponent<ChangeStatus>()
                .Set<string>(e => e.CurrentStatus, ticket.Status)
                .Set(e => e.ticketId, ticketId)
                .Set<string>(e => e.userId, ticket.UserId)
                .Set<string>(e => e.ManagerUserId, ticket.ManagerUserId)
                .Set(e => e.OnClose, EventCallback.Factory.Create(this, RefreshTicketDetails));

            var result = await ModalService.ShowAsync("Cambiar Estado de la Solicitud", component, new ModalOptions { Size = ModalSize.Medium });




        }

        private async Task ResponseTicket()
        {


            var component = new RenderComponent<ResponseTickets>()
                .Set(e => e.ticket, ticket)
                .Set<string>(e => e.statusText, statusText)
                .Set(e => e.OnClose, EventCallback.Factory.Create(this, RefreshTicketDetails));

            var result = await ModalService.ShowAsync("Responder Solicitud", component, new ModalOptions { Size = ModalSize.Maximized });




        }

        private async Task SubmitCommentAsync(string comment)
        {
            // Lógica para manejar el comentario enviado
            // Por ejemplo, guardar el comentario en la base de datos y verificar `SendByEmail`
            Console.WriteLine($"Comentario enviado: {comment}");
        }
    }
}