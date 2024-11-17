using AutoMapper;
using IRIS.Conecta.Application.Features.Notifications.Commands.CreateNotification;
using IRIS.Conecta.Domain.Entities.Tickets;

namespace IRIS.Conecta.Application.MappingProfiles
{
    public class NotificationsProfile : Profile
    {
        public NotificationsProfile()
        {
            CreateMap<Notifications, CreateNotificationCommand>();
        }
    }
}
