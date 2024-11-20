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

        public List<TicketManageListVM>? tickets { get; set; }
        public List<ManagersListVM> managers { get; set; } 

        private static List<TicketManageListVM> selectedOrders = new List<TicketManageListVM>();
        private bool isLoading = false;


        protected override async Task OnInitializedAsync()
        {
            isLoading = true;

            await ListAsync();

        }

        private async Task<bool> ListAsync()
        {
            var responseHttp = await Repository.GetAsync<List<TicketManageListVM>>("/api/Tickets");

            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                isLoading = false;
                return false;
            }

            tickets = responseHttp.Response;


            if (!await GetListManagersAsync())
                return false;


            foreach (var ticket in tickets)
            {
                var manager = managers.FirstOrDefault(m => m.Id == ticket.ManagerUserId);
                if (manager != null)
                {
                    ticket.ManagerName = manager.FullName;
                }
            }

            return true;
        }

        private async Task<bool> GetListManagersAsync()
        {
            var responseHttp = await Repository.GetAsync<List<ManagersListVM>>("/api/Users/GetManagers");

            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                return false;
            }

            managers = responseHttp.Response;

            return true;
        }

        private string GetTicketStatusColor(TicketManageListVM ticket)
        {
            var daysDiff = (DateTime.Now - ticket.DateCreated).Days;

            // Determine the color based on the difference in days
            if (daysDiff <= 1)
            {
                return TablerColor.Green.ToString();
            }
            else if (daysDiff <= 3)
            {
                return TablerColor.Warning.ToString();
            }
            else
            {
                return TablerColor.Red.ToString();
            }
        }

        private async Task OnItemEdit(TicketManageListVM ticket)
        {
            await ShowDialog($"Edited order {ticket.Id}");
        }

        private async Task OnItemAdd(TicketManageListVM ticket)
        {
            await ShowDialog($"Added order {ticket.Id}");
        }

        private async Task OnItemDelete(TicketManageListVM ticket)
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

        private Task<TicketManageListVM> AddItem()
        {
            return Task.FromResult(new TicketManageListVM
            {
                Id = 1, // o cualquier otro valor que desees asignar
                Status = "Open", // Asigna el estado correspondiente

            });
        }





    }
}