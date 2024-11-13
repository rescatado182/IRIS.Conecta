using AutoMapper;
using IRIS.Conecta.Application.Features.Tickets.Dtos;
using IRIS.Conecta.Domain.Entities.Tickets;

namespace IRIS.Conecta.Application.MappingProfiles
{
    public class TicketsViewProfile : Profile
    {
        public TicketsViewProfile()
        {
            CreateMap<TicketsView, TicketByIdDto>().ReverseMap();
            CreateMap<TicketsView, TicketsListDto>();
        }
    }
}
