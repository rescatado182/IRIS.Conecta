using DocumentFormat.OpenXml.Spreadsheet;
using IRIS.Frontend.Repositories;
using IRIS.UI.Icons;
using IRIS.UI.Models;
using IRIS.UI.Models.Enums;
using IRIS.UI.Models.List;
using IRIS.UI.Models.Save;
using IRIS.UI.Models.Update;
using IRIS.UI.Services;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using TabBlazor;
using TabBlazor.Components.Modals;
using TabBlazor.Services;

namespace IRIS.UI.Pages.BL.Tickets.ResponseTickets
{
    public partial class ResponseTickets
    {

        [Inject] IModalService ModalService { get; set; }
        [Inject] private IRepository Repository { get; set; } = null!;

        [Inject] private INotificationService NotificationService { get; set; }
        [Parameter] public EventCallback OnClose { get; set; }
        [Parameter] public GetTicketbyIdVM ticket { get; set; } = null!;
        [Parameter] public string statusText { get; set; } = null!;

        public ResponseTicketsVM respuesta { get; set; } = new ResponseTicketsVM();

        private async Task OnSubmit()
        {
            try
            {
                // Ejecutar la respuesta del ticket
                await ResponseTicketAsync();

                // Mostrar mensaje de éxito
                await ModalService.ShowDialogAsync(new DialogOptions
                {
                    MainText = "Respuesta Exitosa",
                    SubText = $"Has respondido la solicitud {ticket.Id}. Le enviaremos la información por correo al solicitante!",
                    IconType = TablerIcons.Message,
                    CancelText = "",
                    StatusColor = TablerColor.Primary
                });

                // Invocar el evento OnClose si está definido
                if (OnClose.HasDelegate)
                {
                    await OnClose.InvokeAsync();
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores: mostrar mensaje de error
                await ModalService.ShowDialogAsync(new DialogOptions
                {
                    MainText = "Error",
                    SubText = $"Ocurrió un error al procesar la solicitud: {ex.Message}",
                    IconType = TablerIcons.Alert_circle,
                    CancelText = "",
                    StatusColor = TablerColor.Red
                });
            }
            finally
            {
                // Cerrar el modal principal
                ModalService.Close();
            }
        }


        private ChangeStatusVM CreateChangeStatus(int? idTicket, string? userId, string? ManagerUserId)
        {
            return new ChangeStatusVM
            {
                Id = idTicket.Value,
                Status = TicketsStatus.Resolved.ToString(),
                UserId = userId,
                ManagerUserId = ManagerUserId
            };
        }

        /// <summary>
        /// Llama al repositorio para actualizar el estado del ticket.
        /// </summary>
        private async Task ChangeStatusAsync(int? idTicket, string? userId, string? ManagerUserId)
        {
            var changeStatus = CreateChangeStatus(idTicket, userId, ManagerUserId);
            LogJsonPayload(changeStatus);

            var responseHttp = await Repository.PutAsync("/api/tickets/changeticketstatus", changeStatus);
            if (responseHttp.Error){ 

                var message = await responseHttp.GetErrorMessageAsync();
                Console.WriteLine($"Error al cambiar el estado: {message}");
            }
        }

        private async Task ResponseTicketAsync()
        {

            await SendNotification();
            await ChangeStatusAsync(ticket.Id, ticket.UserId, ticket.ManagerUserId);

        }

        private async Task SendNotification()
        {
            var notification = new NotificationVM
            {
                Message = $"Se respondió solicitud",
                SendEmail = true,
                TicketId = ticket.Id,
                NotificationType = NotificationType.Response.ToString()
            };

            try
            {
                await NotificationService.SendNotificationAsync(notification);
                Console.WriteLine("Notificación enviada exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar notificación: {ex.Message}");
            }
        }

        private void LogJsonPayload(object data)
        {
            string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(jsonString);
        }
    }
}