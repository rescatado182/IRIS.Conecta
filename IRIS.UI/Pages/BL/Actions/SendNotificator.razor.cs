using IRIS.UI.Icons;
using IRIS.UI.Models.Enums;
using IRIS.UI.Models.Save;
using IRIS.UI.Services;
using Microsoft.AspNetCore.Components;
using TabBlazor;
using TabBlazor.Components.Modals;
using TabBlazor.Services;

namespace IRIS.UI.Pages.BL.Actions
{
    public partial class SendNotificator
    {
        [Inject] private INotificationService NotificationService { get; set; }

        [Inject] public IModalService Modal { get; set; }

        [Parameter] public EventCallback OnClose { get; set; }

        [Parameter]
        public EventCallback<string> OnSubmit { get; set; }


        [Parameter]
        public bool SendEmail { get; set; }

        [Parameter] public int ticketId { get; set; }


        private string CommentText { get; set; } = string.Empty;
        private bool SendByEmail { get; set; } = false;
        private bool IsSubmitting { get; set; } = false;

        private async Task OnSubmitAsync()
        {
            if (string.IsNullOrWhiteSpace(CommentText))
            {
                await Modal.ShowDialogAsync(new DialogOptions
                {
                    MainText = "Error",
                    SubText = "El comentario no puede estar vacío.",
                    IconType = TablerIcons.Alert_circle,
                    StatusColor = TablerColor.Red,
                    CancelText = ""

                });
                return;
            }



            try
            {
                // Crear el objeto de notificación
                var notification = new NotificationVM
                {
                    Message = CommentText,
                    SendEmail = true,
                    TicketId = ticketId,
                    NotificationType = NotificationType.Notification.ToString(), // Tipo de notificación
                    DateCreated = DateTime.Now
                };

                // Enviar la notificación
                await NotificationService.SendNotificationAsync(notification);

                // Mostrar modal de éxito
                await Modal.ShowDialogAsync(new DialogOptions
                {
                    MainText = "Respuesta Exitosa",
                    SubText = $"Has respondido la solicitud {ticketId}. Le enviaremos la información por correo al solicitante.",
                    IconType = TablerIcons.Message,
                    StatusColor = TablerColor.Primary,
                    CancelText = "",
                    OkText = "Cerrar"
                });

                // Limpia el formulario después del envío exitoso
                CommentText = string.Empty;
                SendByEmail = false;

                // Llama al evento de cierre si se ha definido
                if (OnClose.HasDelegate)
                {
                    await OnClose.InvokeAsync();
                }
            }
            catch (Exception ex)
            {
                // Mostrar modal de error
                await Modal.ShowDialogAsync(new DialogOptions
                {
                    MainText = "Error",
                    SubText = $"Error al enviar el comentario: {ex.Message}",
                    IconType = TablerIcons.Alert_circle,
                    StatusColor = TablerColor.Red,
                    CancelText = "",

                });
            }
            finally
            {
                IsSubmitting = false;
            }
        }

    }
}