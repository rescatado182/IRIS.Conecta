using DocumentFormat.OpenXml.Spreadsheet;
using IRIS.Frontend.Repositories;
using IRIS.UI.Data;
using IRIS.UI.Icons;
using IRIS.UI.Models;
using IRIS.UI.Models.Enums;
using IRIS.UI.Models.List;
using IRIS.UI.Models.Save;
using IRIS.UI.Models.Update;
using IRIS.UI.Pages.BL.Tickets.RequestTickets.Movility;
using IRIS.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using TabBlazor;
using TabBlazor.Components.Modals;
using TabBlazor.Services;
using static IRIS.UI.EnumExtensions;

namespace IRIS.UI.Pages.BL.Actions
{
    public partial class EscalateTicket
    {

        [Inject] private INotificationService NotificationService { get; set; }

        [Inject] public IModalService Modal { get; set; }
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] IModalService ModalService { get; set; }

        [Parameter]
        public EventCallback<ManagersListVM> OnStatusChanged { get; set; }

        [Parameter] public EventCallback OnClose { get; set; }

        public List<ManagersListVM> managers { get; set; }

        [Parameter] public int ticketId { get; set; }

        [Parameter] public string userId { get; set; }

        [Parameter] public string ManagerUserId { get; set; }

        [Parameter] public string CurrentStatus { get; set; }

        private string CurrentManager { get; set; }

        private string CurrentManagerId;

        private ManagersListVM SelectedStatus { get; set; }

        private ManagersListVM selectedManager;


        // Cambiar la definición de filteredStatuses a una lista de EnumItem<TicketsStatus>



        protected override async Task OnInitializedAsync()
        {
            await GetManagersAsync();

            var managersList = SearchManagersbyId(ManagerUserId);
            CurrentManager = managersList.FirstOrDefault()?.FullName;
            CurrentManagerId = managersList.FirstOrDefault()?.Id;
        }

        private IEnumerable<ManagersListVM> SearchManagersbyId(string ManagerUserId)
        {
            return managers.Where(c => c.Id == ManagerUserId);
        }

        private async Task CloseOffcanvas()
        {
            await OnClose.InvokeAsync(); // Llama al callback cuando el Offcanvas se cierra
        }

        private async Task GetManagersAsync()
        {
            var responseHttp = await Repository.GetAsync<List<ManagersListVM>>("/api/users/getmanagers");

            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                return;
            }
            managers = responseHttp.Response;
            return;



        }
        private async Task OnItemSelected<T>(T selectedItem)
        {
            selectedManager = selectedItem as ManagersListVM;

        }

        private async Task<IEnumerable<ManagersListVM>> SearchManagers(string searchText)
        {
            return managers.Where(c => c.FullName.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task OnSubmitAsync()
        {
            if (CurrentManagerId != selectedManager.Id)
            {
                // Cambiar el gerente del ticket
                await ChangeManagerAsync(ticketId, userId, selectedManager.Id, CurrentStatus);

                // Mostrar mensaje de confirmación
                await ModalService.ShowDialogAsync(new DialogOptions
                {
                    MainText = "Solicitud Escalada",
                    SubText = $"Has cambiado la solicitud a {selectedManager.FullName}!",
                    IconType = TablerIcons.Message,
                    CancelText = "",
                    StatusColor = TablerColor.Primary
                });

                // Cerrar este modal
                ModalService.Close();

                // Invocar la acción de cierre definida en OnClose
                if (OnClose.HasDelegate)
                {
                    await OnClose.InvokeAsync();
                }

                try
                {
                    var notification = new NotificationVM
                    {
                        Message = $"Solicitud escalada a {selectedManager.FullName}!",
                        SendEmail = false,
                        TicketId = ticketId,
                        ManagerUserId = userId,
                        NotificationType = NotificationType.Notification.ToString(),
                        DateCreated = DateTime.Now
                    };

                    await NotificationService.SendNotificationAsync(notification);


                    // Cierra este modal y cualquier modal principal si aplica
                    Modal.Close();
                    if (OnClose.HasDelegate)
                    {
                        await OnClose.InvokeAsync();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return;
            }
        }

        private void LogJsonPayload(object data)
        {
            string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(jsonString);
        }

        private ChangeStatusVM CreateChangeManager(int? idTicket, string? userId, string? CurrentManagerId, string CurrentStatus)
        {

            return new ChangeStatusVM
            {
                Id = idTicket.Value,
                Status = CurrentStatus.ToString(),
                UserId = userId,
                ManagerUserId = CurrentManagerId
            };

        }
        private async Task ChangeManagerAsync(int? idTicket, string? userId, string? ManagerUserId, string CurrentStatus)
        {
            ChangeStatusVM changeStatus = CreateChangeManager(idTicket, userId, ManagerUserId, CurrentStatus);

            LogJsonPayload(changeStatus);

            var responseHttp = await Repository.PutAsync("/api/tickets/changeticketstatus", changeStatus);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();

            }

        }



    }
}