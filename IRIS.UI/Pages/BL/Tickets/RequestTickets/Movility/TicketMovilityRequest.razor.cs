using ColorCode.Compilation.Languages;
using IRIS.Frontend.Repositories;
using IRIS.UI.Models;
using IRIS.UI.Pages.BL.Tickets.Shared;
using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;
using System.Net;
using System.Text.Json;
using System.Web.Mvc;
using TabBlazor;
using TabBlazor.Components.Modals;
using TabBlazor.Services;

namespace IRIS.UI.Pages.BL.Tickets.RequestTickets.Movility
{
    public partial class TicketMovilityRequest
    {

        [Inject] public IModalService Modal { get; set; }
        [Inject] public ToastService ToastService { get; set; }

        private ToastOptions toastOptions = new ToastOptions();

        [Inject] private IRepository Repository { get; set; } = null!;

        private bool isCompleted1 = false;
        private bool isCompleted2 = false;
        private bool isCompleted3 = false;

        private PersonalDataTicket personalDataRef;

        public List<TicketVM>? ticket { get; set; }

        private TabsOrder tabsOrderRef;

        private int CurrentTabIndex { get; set; } = 5;

        private bool IsLastTab => tabsOrderRef?.IsLastTab ?? false;

        private int? idTicket = null;

        private async Task NextStepAsync()
        {
            bool isValidPersonalData = false;

            //crear ticket
            if (idTicket == null)
            {
                idTicket = await CreateTicketAsync();
                if (idTicket.HasValue)
                {
                    Console.WriteLine($"Ticket creado con Id: {idTicket.Value}");

                }
            }

            //validarCampos PersonalData
            if (isValidPersonalData == false)
            {
                isValidPersonalData = await ValidatePersonalDataAsync();
            }
            
            

            if (tabsOrderRef != null && isValidPersonalData)
            {
                tabsOrderRef.NextTab(); 
            }
            else
            {
                Console.WriteLine("No se pudo obtener la referencia de TabsOrder");
            }
        }

        private async Task<int?> CreateTicketAsync()
        {
            object jsonResult;

            var ticket = new TicketVM
            {
                Title = "Movility",
                Description = "Movility",
                RequestTypeId = 1,
                Status = TicketsStatus.Open
            };


            var responseHttp = await Repository.PostAsync("/api/tickets", ticket);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                Console.WriteLine(message);
                return null;
            }
            var resultContent = responseHttp.HttpResponseMessage.Content.ReadAsStringAsync().Result;

            using (var jsonDocument = JsonDocument.Parse(resultContent))
            {
                var id = jsonDocument.RootElement.GetProperty("id").GetInt32();

                return id;
            }
        }

        private async Task<bool> ValidatePersonalDataAsync()
        {
            ;

            if (personalDataRef != null)
            {
                var resultValid = personalDataRef.ValidatePersonalDataAsync();

                if (resultValid.Count() >= 0)
                {
                    foreach (var validationResult in resultValid)
                    {
                        await ToastService.AddToastAsync(new ToastModel { Title = "Formulario Incompleto", SubTitle = "", Message = validationResult.ErrorMessage});
                    }

                    return false;
                }
            }
            return true;
        }
    }
}