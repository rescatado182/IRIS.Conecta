using FluentValidation;
using IRIS.Conecta.Application.Contracts.Persistence.Tickets;

namespace IRIS.Conecta.Application.Features.Notifications.Commands.CreateNotification
{
    public class CreateNotificationValidation : AbstractValidator<CreateNotificationCommand>
    {
        private readonly ITicketsRepository _ticketsRepository;

        public CreateNotificationValidation(ITicketsRepository ticketsRepository)
        {
            _ticketsRepository = ticketsRepository;

            RuleFor(p => p.Message)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull()
                .MaximumLength(300).WithMessage("{PropertyName} no debe exceder {ComparisonValue} carácteres.");

            RuleFor(p => p.NotificationType)
                .IsInEnum()
                .NotEmpty().WithMessage("{PropertyName} es requerido.");

            RuleFor(p => p.SendEmail)
                .NotEmpty().WithMessage("{PropertyName} es requerido.");

            RuleFor(p => p.TicketId)
                .GreaterThan(0)
                .NotNull()
                .MustAsync(async (id, token) =>
                {
                    var ticketExists = await _ticketsRepository.GetByIdAsync(id);
                    return ticketExists != null;
                })
                .WithMessage("{PropertyName} no existe.");            
        }
    }
}
