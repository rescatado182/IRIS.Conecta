using IRIS.UI.Icons;
using IRIS.UI.Models.Enums;
using IRIS.UI.Models.Save;
using IRIS.UI.Services;
using Microsoft.AspNetCore.Components;
using System;
using TabBlazor;

namespace IRIS.UI.Pages.BL.Actions
{
    public partial class ViewTrackingTicket
    {
        [Inject] private INotificationService NotificationService { get; set; }
        private List<NotificationVM> Notifications { get; set; } = new();

        [Parameter] public int ticketId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {

                Notifications = await NotificationService.GetNotificationsAsync(ticketId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar las notificaciones: {ex.Message}");
            }
        }

        private string GetTitle(NotificationType type)
        {
            return type switch
            {
                NotificationType.Notification => "Notificación",
                NotificationType.ChangeStatus => "Cambio de Estado",
                NotificationType.Escalate => "Escalamiento",
                NotificationType.Response => "Respuesta",
                _ => "Desconocido"
            };
        }

        private TablerColor GetIconColor(NotificationType type)
        {
            return type switch
            {
                NotificationType.Notification => TabBlazor.TablerColor.Green,
                NotificationType.ChangeStatus => TabBlazor.TablerColor.Purple,
                NotificationType.Escalate => TabBlazor.TablerColor.Red,
                NotificationType.Response => TabBlazor.TablerColor.Blue,
                _ => TabBlazor.TablerColor.Secondary
            };
        }
        private IIconType GetIcon(NotificationType type)
        {
            return type switch
            {
                NotificationType.Notification => TablerIcons.Notification,
                NotificationType.ChangeStatus => TablerIcons.Status_change,
                NotificationType.Escalate => TablerIcons.User,
                NotificationType.Response => TablerIcons.Check,
                _ => TablerIcons.Info_circle
            };
        }
    }
}