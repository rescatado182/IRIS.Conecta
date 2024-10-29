using DocumentFormat.OpenXml.Spreadsheet;
using IRIS.Frontend.Repositories;
using IRIS.UI.Models;
using IRIS.UI.Models.List;
using IRIS.UI.Pages.BL.Actions;
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

        [Inject] IOffcanvasService offcanvasService { get; set; }

        private TicketsStatus CurrentStatus = TicketsStatus.Open;

        public TicketListVM ticket { get; set; }

        [Parameter] public int ticketId { get; set; }

        protected override async Task OnInitializedAsync()
        {

            await GetDetailTicket();

        }

        private async Task<bool> GetDetailTicket()
        {

            var responseHttp = await Repository.GetAsync<TicketListVM>($"/api/Tickets/{ticketId}");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();


                return false;
            }
            ticket = responseHttp.Response;


            //tickets = responseHttp.Response;
            return true;
        }

        private TabBlazor.OffcanvasOptions options = new()
        {
            CloseOnEsc = true,
            CloseOnClickOutside = true,
            Position = TabBlazor.OffcanvasPosition.End
        };

        private async Task OpenCommentOffcanvas()
        {
            // Define the component `CreateComments` and configure its properties
            var component = new RenderComponent<CreateComments>()
                .Set(e => e.OnSubmit, EventCallback.Factory.Create<string>(this, SubmitCommentAsync));

            // Open the Offcanvas with the comment form
            await offcanvasService.ShowAsync("Comentario para el Ticket", component, options);
        }

        

        private async Task OpenStatusOffcanvas()
        {
            // Define the component `ChangeStatus` and configure its properties
            var component = new RenderComponent<ChangeStatus>()
                .Set(e => e.CurrentStatus, CurrentStatus)
                .Set(e => e.OnStatusChanged, EventCallback.Factory.Create<TicketsStatus>(this, ChangeStatusAsync));

            // Open the Offcanvas with the status form
            await offcanvasService.ShowAsync("Cambiar estado del Ticket", component, options);
        }

        private void UpdateStatus(TicketsStatus newStatus)
        {
            CurrentStatus = newStatus;
            // Aquí puedes agregar lógica para actualizar el estado en el backend o en la base de datos
        }
        private void ChangeStatusAsync()
        {
            throw new NotImplementedException();
        }

        private async Task SubmitCommentAsync(string comment)
        {
            // Lógica para manejar el comentario enviado
            // Por ejemplo, guardar el comentario en la base de datos y verificar `SendByEmail`
            Console.WriteLine($"Comentario enviado: {comment}");
        }
    }
}