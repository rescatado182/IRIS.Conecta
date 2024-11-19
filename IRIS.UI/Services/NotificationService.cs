using IRIS.UI.Models.Save;
using System.Net.Http.Json;

namespace IRIS.UI.Services
{
    public class NotificationService : INotificationService
    {
        private readonly HttpClient _httpClient;

        public NotificationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendNotificationAsync(NotificationVM notification)
        {
            if (notification == null) throw new ArgumentNullException(nameof(notification));

            // Serializar y enviar la notificación
            var response = await _httpClient.PostAsJsonAsync("api/notifications", notification);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<NotificationVM>> GetNotificationsAsync(int ticketId)
        {
            var response = await _httpClient.GetFromJsonAsync<List<NotificationVM>>($"api/notifications/getnotificationsbyticketid/{ticketId}");
            return response ?? new List<NotificationVM>();
        }
    }
}
