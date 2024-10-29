using IRIS.Frontend.Repositories;
using IRIS.UI.Data;
using IRIS.UI.Icons;
using IRIS.UI.Models;
using IRIS.UI.Models.List;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using TabBlazor;
using TabBlazor.Services;

namespace IRIS.UI.Pages.BL.ManageTickets
{
    public partial class ManageTicketsIndex
    {
        [Inject] IJSRuntime JSRuntime { get; set; }
        [Inject] TablerService TablerService { get; set; }
        [Inject] IModalService ModalService { get; set; }


        [Inject] private NavigationManager NavigationManager { get; set; } = null!;

        [Inject] private IRepository Repository { get; set; } = null!;

        public List<TicketListVM>? tickets { get; set; }

        private static List<TicketListVM> selectedOrders = new List<TicketListVM>();

        protected override async Task OnInitializedAsync()
        {


            await ListAsync();

        }

        private async Task<bool> ListAsync()
        {


            // var responseHttp = await Repository.GetAsync<List<TicketListVM>>("/api/Tickets");
            var responseHttp = await Repository.GetAsync<TicketListVM>("/api/Tickets/1117");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();


                return false;
            }
            var singleTicket = responseHttp.Response;
            tickets = new List<TicketListVM> { singleTicket };

            //tickets = responseHttp.Response;
            return true;
        }

        private async Task OnItemEdit(TicketListVM ticket)
        {
            await ShowDialog($"Edited order {ticket.Id}");
        }

        private async Task OnItemAdd(TicketListVM ticket)
        {
            await ShowDialog($"Added order {ticket.Id}");
        }

        private async Task OnItemDelete(TicketListVM ticket)
        {
            await ShowDialog($"Order deleted {ticket.Id}");
        }

        private async Task ShowDialog(string title)
        {
            await ModalService.ShowDialogAsync(new TabBlazor.Components.Modals.DialogOptions
            {
                CancelText = "",
                StatusColor = TablerColor.Primary,
                IconType = @TablerIcons.Info_circle,
                MainText = title
            });
        }

        private Task<TicketListVM> AddItem()
        {
            return Task.FromResult(new TicketListVM
            {
                Id = 1, // o cualquier otro valor que desees asignar
                Title = "Nuevo ticket",
                Description = "Descripción del nuevo ticket",
                Status = "Open", // Asigna el estado correspondiente
                RequestTypeId = 1 // Asigna el ID del tipo de solicitud correspondiente
            });
        }





    }
}