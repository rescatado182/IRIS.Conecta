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
        [Parameter] public string userId { get; set; }

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
                var notification = new NotificationVM
                {
                    Message = CommentText,
                    SendEmail = true,
                    TicketId = ticketId,
                    ManagerUserId = userId,
                    NotificationType = NotificationType.Notification.ToString(),
                    DateCreated = DateTime.Now
                };

                await NotificationService.SendNotificationAsync(notification);

                // Mostrar modal de éxito
                await Modal.ShowDialogAsync(new DialogOptions
                {
                    MainText = "Comentario Exitoso",
                    SubText = "Enviaremos tu comentario por correo al usuario de la solicitud.",
                    IconType = TablerIcons.Message,
                    StatusColor = TablerColor.Primary,
                    CancelText = "",
                    OkText = "Cerrar"
                });

                // Limpiar y cerrar
                CommentText = string.Empty;
                SendByEmail = false;

                // Cierra este modal y cualquier modal principal si aplica
                Modal.Close();
                if (OnClose.HasDelegate)
                {
                    await OnClose.InvokeAsync();
                }
            }
            catch (Exception ex)
            {
                await Modal.ShowDialogAsync(new DialogOptions
                {
                    MainText = "Error",
                    SubText = $"Error al enviar el comentario: {ex.Message}",
                    IconType = TablerIcons.Alert_circle,
                    StatusColor = TablerColor.Red,
                    CancelText = ""
                });
            }
            finally
            {
                IsSubmitting = false;
            }
        }


    }
}