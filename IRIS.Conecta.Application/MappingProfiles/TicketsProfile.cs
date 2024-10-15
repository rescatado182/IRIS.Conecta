using AutoMapper;
using IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.CreateTicket;
using IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.UpdateTicket;
using IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.UpdateTicketByMovility;
using IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.UpdateTicketByRequirements;
using IRIS.Conecta.Application.Features.Tickets.Dtos;
using IRIS.Conecta.Domain.Entities;

namespace IRIS.Conecta.Application.MappingProfiles
{
    public class TicketsProfile : Profile
    {
        public TicketsProfile()
        {
            CreateMap<Ticket, CreateTicketDto>().ReverseMap();
            CreateMap<Ticket, UpdateTicketDto>().ReverseMap();
            CreateMap<Ticket, UpdateTicketByMovilityDto>().ReverseMap();
            CreateMap<Ticket, UpdateTicketByRequirementsDto>().ReverseMap();

            CreateMap<Ticket, TicketByIdDto>().ReverseMap();
            CreateMap<Ticket, TicketsListDto>();
        }
    }
}
