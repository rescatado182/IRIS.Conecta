using DocumentFormat.OpenXml.Spreadsheet;
using IRIS.Frontend.Repositories;
using IRIS.UI.Icons;
using IRIS.UI.Models.List;
using IRIS.UI.Models.Save;
using Microsoft.AspNetCore.Components;
using TabBlazor;
using TabBlazor.Components.Modals;
using TabBlazor.Services;

namespace IRIS.UI.Pages.BL.Tickets.ResponseTickets
{
    public partial class ResponseTickets
    {

        [Inject] IModalService ModalService { get; set; }
        [Inject] private IRepository Repository { get; set; } = null!;
        [Parameter] public EventCallback OnClose { get; set; }
        [Parameter] public GetTicketbyIdVM ticket { get; set; } = null!;
        [Parameter] public string statusText { get; set; } = null!;

        public ResponseTicketsVM respuesta { get; set; } = new ResponseTicketsVM();

        private async Task OnSubmit()
        {


            await ResponseTicketAsync();


            await ModalService.ShowDialogAsync(new DialogOptions
            {
                MainText = "Respuesta Existosa",
                SubText = $"Has respondido la solicitud {ticket.Id}. Le enviaremos la información por correo al solicitante!",
                IconType = TablerIcons.Message,
                CancelText = "",
                StatusColor = TablerColor.Primary
            });
            await OnClose.InvokeAsync();
            return;


        }

        private async Task ResponseTicketAsync()
        {

            //var responseHttp = await Repository.PutAsync("/api/tickets/response", respuesta);
            //if (responseHttp.Error)
            //{
            //    var message = await responseHttp.GetErrorMessageAsync();
            //    Console.WriteLine($"Error al cambiar el estado: {message}");
            //}
        }
    }
}