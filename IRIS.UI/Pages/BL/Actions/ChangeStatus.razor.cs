
using IRIS.Frontend.Repositories;
using IRIS.UI.Icons;
using IRIS.UI.Models;
using IRIS.UI.Models.List;
using IRIS.UI.Models.Save;
using IRIS.UI.Models.Update;
using IRIS.UI.Pages.BL.ManageTickets;
using IRIS.UI.Pages.BL.Tickets.RequestTickets.Movility;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using TabBlazor;
using TabBlazor.Components.Modals;
using TabBlazor.Services;
using static IRIS.UI.EnumExtensions;

namespace IRIS.UI.Pages.BL.Actions
{
    public partial class ChangeStatus
    {
        [Inject] TicketMovilityRequest MovilityRequestState { get; set; }

        [Inject] private IRepository Repository { get; set; } = null!;

        [Inject] IModalService ModalService { get; set; }


        [Parameter] public EventCallback OnClose { get; set; }
        [Parameter] public string CurrentStatus { get; set; } // Estado actual como string
        [Parameter] public int ticketId { get; set; }
        [Parameter] public string userId { get; set; }
        [Parameter] public string ManagerUserId { get; set; }

        private TicketsStatus _selectedStatus;

        private string CurrentStatusText { get; set; } 

        /// <summary>
        /// Estado seleccionado actualmente como enum. Actualiza también el estado como string y su DisplayName.
        /// </summary>
        public TicketsStatus SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                _selectedStatus = value;

                // Sincroniza el string del estado
                CurrentStatus = _selectedStatus.ToString();

                // Muestra el DisplayName asociado al estado seleccionado
                CurrentStatusDisplayNameText = _selectedStatus.GetDisplayName();
            }
        }


        public string CurrentStatusDisplayNameText { get; private set; }

 
        private IEnumerable<(TicketsStatus Status, string DisplayName)> StatusList =>
            Enum.GetValues<TicketsStatus>()
                .Select(status => (status, status.GetDisplayName()))
                .ToList();

        /// <summary>
        /// Inicializa la lista de estados filtrados.
        /// </summary>
        private List<EnumItem<TicketsStatus>> enumTicketStatus { get; set; }

        protected override void OnInitialized()
        {
            // Sincronizar el estado inicial basado en CurrentStatus
            if (Enum.TryParse(typeof(TicketsStatus), CurrentStatus, true, out var enumValue))
            {
                SelectedStatus = (TicketsStatus)enumValue;
            }
            else
            {
                SelectedStatus = TicketsStatus.Open;
            }

            // Filtrar los estados para mostrar
            enumTicketStatus = EnumExtensions.GetList<TicketsStatus>()
                .Where(status =>
                    status.Value == TicketsStatus.Cancelled ||
                    status.Value == TicketsStatus.Resolved ||
                    status.Value == TicketsStatus.InProcess ||
                    status.Value == TicketsStatus.Closed)
                .ToList();

            CurrentStatusText = CurrentStatusDisplayNameText;
        }

        private async Task OnSubmit()
        {

                // Llamada a la API para cambiar el estado
                await ChangeStatusAsync(ticketId, userId, ManagerUserId);

                CurrentStatusText = CurrentStatusDisplayNameText;

                await ModalService.ShowDialogAsync(new DialogOptions
                {
                    MainText = "Cambio de Estado",
                    SubText = $"Has cambiado el estado a {SelectedStatus.GetDisplayName()}!",
                    IconType = TablerIcons.Message,
                    CancelText = "",
                    StatusColor = TablerColor.Primary
                });
                 await OnClose.InvokeAsync();
            return;


        }

        /// <summary>
        /// Crea el ViewModel para enviar al servidor.
        /// </summary>
        private ChangeStatusVM CreateChangeStatus(int? idTicket, string? userId, string? ManagerUserId, TicketsStatus SelectedStatus)
        {
            return new ChangeStatusVM
            {
                Id = idTicket.Value,
                Status = SelectedStatus.ToString(),
                UserId = userId,
                ManagerUserId = ManagerUserId
            };
        }

        /// <summary>
        /// Llama al repositorio para actualizar el estado del ticket.
        /// </summary>
        private async Task ChangeStatusAsync(int? idTicket, string? userId, string? ManagerUserId)
        {
            var changeStatus = CreateChangeStatus(idTicket, userId, ManagerUserId, SelectedStatus);
            LogJsonPayload(changeStatus);

            var responseHttp = await Repository.PutAsync("/api/tickets/changeticketstatus", changeStatus);
            if (!responseHttp.Error)
            {
                // Sincroniza _selectedStatus con el estado actualizado
                _selectedStatus = SelectedStatus; // Esto refleja el nuevo estado después de la actualización

                // Actualiza CurrentStatus con el valor del enum seleccionado
                CurrentStatus = SelectedStatus.ToString();

                // Ya no actualizamos CurrentStatusDisplayNameText aquí, porque se hará en OnSubmit después de que ChangeStatusAsync se complete.
            }
            else
            {
                var message = await responseHttp.GetErrorMessageAsync();
                Console.WriteLine($"Error al cambiar el estado: {message}");
            }
        }

        /// <summary>
        /// Registra el payload en formato JSON.
        /// </summary>
        private void LogJsonPayload(object data)
        {
            string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(jsonString);
        }
    }
}
