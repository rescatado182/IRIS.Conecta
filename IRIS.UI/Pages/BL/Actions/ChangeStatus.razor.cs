using IRIS.UI.Models;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using static IRIS.UI.EnumExtensions;

namespace IRIS.UI.Pages.BL.Actions
{
    public partial class ChangeStatus
    {
        [Parameter]
        public TicketsStatus CurrentStatus { get; set; }

        [Parameter]
        public EventCallback<TicketsStatus> OnStatusChanged { get; set; }

        private TicketsStatus SelectedStatus { get; set; }

        // Cambiar la definición de filteredStatuses a una lista de EnumItem<TicketsStatus>
        private List<EnumItem<TicketsStatus>> enumTicketStatus { get; set; }

        private string CurrentStatusDisplayName => EnumExtensions.GetDisplayName(CurrentStatus);

        private IEnumerable<(TicketsStatus Status, string DisplayName)> StatusList =>
            Enum.GetValues<TicketsStatus>()
                .Cast<TicketsStatus>()
                .Select(status => (status, EnumExtensions.GetDisplayName(status)))
                .ToList();

        protected override void OnInitialized()
        {
            // Cambiar la lista para que sea de EnumItem<TicketsStatus> en lugar de TicketsStatus
            enumTicketStatus = EnumExtensions.GetList<TicketsStatus>()
            .Where(status =>
                status.Value == TicketsStatus.Committee ||
                status.Value == TicketsStatus.InProcess ||
                status.Value == TicketsStatus.Closed)
            .ToList();
        }

        private async Task OnSubmit()
        {
            if (SelectedStatus != CurrentStatus)
            {
                await OnStatusChanged.InvokeAsync(SelectedStatus);
                // Puedes cerrar el offcanvas después de guardar los cambios
            }




        }
    }
}
