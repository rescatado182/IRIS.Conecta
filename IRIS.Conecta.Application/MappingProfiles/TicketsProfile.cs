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
            CreateMap<CreateTicketCommand, Ticket>().ReverseMap();
            CreateMap<UpdateTicketCommand, Ticket>().ReverseMap();
            CreateMap<UpdateTicketByMovilityCommand, Ticket>().ReverseMap();
            CreateMap<UpdateTicketByRequirementsCommand, Ticket>().ReverseMap();

            CreateMap<Ticket, TicketByIdDto>().ReverseMap();
            CreateMap<Ticket, TicketsListDto>().ReverseMap();
        }
    }
}
