using IRIS.UI.Models.Save;

namespace IRIS.UI.Services
{
    public interface INotificationService
    {
        Task SendNotificationAsync(NotificationVM notification);

        Task<List<NotificationVM>> GetNotificationsAsync(int ticketId);
    }

}
