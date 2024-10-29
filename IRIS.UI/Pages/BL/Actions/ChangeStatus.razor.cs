using IRIS.UI.Models;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace IRIS.UI.Pages.BL.Actions
{
    public partial class ChangeStatus
    {
        [Parameter]
        public TicketsStatus CurrentStatus { get; set; }

        [Parameter]
        public EventCallback<TicketsStatus> OnStatusChanged { get; set; }

        private TicketsStatus SelectedStatus { get; set; }

        private string CurrentStatusDisplayName =>
            typeof(TicketsStatus)
                .GetMember(CurrentStatus.ToString())[0]
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .Cast<DisplayAttribute>()
                .SingleOrDefault()
                ?.Name ?? CurrentStatus.ToString();

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