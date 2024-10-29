using ColorCode.Compilation.Languages;
using IRIS.Frontend.Repositories;
using IRIS.UI.Interfaces;
using IRIS.UI.Models;
using IRIS.UI.Pages.BL.Tickets.RequestTickets.Movility.Information;
using IRIS.UI.Pages.BL.Tickets.Shared;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
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

        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] public IModalService Modal { get; set; }
        [Inject] public ToastService ToastService { get; set; }


        public PersonalDataVM personalData = new PersonalDataVM();

        private PersonalDataTicket personalDataRef;

        public bool isCompletedPersonalData = false;


        public AcademyDataVM academyData = new AcademyDataVM();

        private AcademyDataTicket academyDataRef;

        public bool isCompletedAcademyData = false;


        public MovilityTypeVM movilityType = new MovilityTypeVM();

        private MovilityTypeTicket movilityTypeRef;

        public bool isCompletedMovilityType = false;

        //public RequirementsMovilityVM requirementsMovility = new RequirementsMovilityVM();

        //private RequirementsMovilityVM requirementsMovilityRef;

        public bool isCompletedRequirementsMovility = false;



        public List<TicketVM>? ticket { get; set; }

        private TabsOrder tabsOrderRef;

       // private int CurrentTabIndex { get; set; } = 2;

        private bool IsLastTab => tabsOrderRef?.IsLastTab ?? false;

        private bool IsFirstTab => tabsOrderRef?.IsFirstTab ?? true;

        private int? idTicket = null;

        
        private bool isCompleted2 = false;
        private bool isCompleted3 = false;

        private async Task PreviousStepAsync()
        {
            tabsOrderRef.PreviousTab();
        }

        private async Task NextStepAsync()
        {

            //crear ticket
            if (idTicket == null)
            {
                idTicket = await CreateTicketAsync();
                if (idTicket.HasValue)
                {
                    Console.WriteLine($"Ticket creado con Id: {idTicket.Value}");

                }
            }

            if (tabsOrderRef != null)
            {
                switch (tabsOrderRef?.CurrentTabIndex)
                {
                    case 0:
                        // Tab 1: Datos personales
                        isCompletedPersonalData = await ValidateDataAsync(personalDataRef);
                        if (!isCompletedPersonalData) return;
                        break;

                    case 1:
                        // Tab 2: Datos académicos
                        isCompletedAcademyData = await ValidateDataAsync(academyDataRef);
                        if (!isCompletedAcademyData) return;
                        break;
                    case 2:

                        // Tab 3: Tipo de movilidad
                        isCompletedMovilityType = await movilityTypeRef.ValidateDatesAsync(movilityType);
                        if (!isCompletedMovilityType) return;

                        isCompletedMovilityType = await ValidateDataAsync(movilityTypeRef);
                        if (!isCompletedMovilityType) return;

                        await movilityTypeRef.UpdateTicketMovilityTypeAsync(idTicket, movilityType);
                        break;
                    case 3:
                        // Tab 4: Requerimientos de la Movilidad
                        //isCompletedRequirementsMovility = await ValidateDataAsync(requirementsMovilityRef);
                        ////if (!isCompletedMovilityType) return;
                        //await UpdateTicketMovilityTypeAsync(idTicket, movilityType);
                        break;
                }
               
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
                Title = "Movilidad",
                Description = "Movilidad",
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

        private async Task<bool> ValidateDataAsync(IValidateData validateData)
        {


            var validationResults = await validateData.ValidateDataAsync();

            if (validationResults.Count() > 0)
            {
                var toastTasks = validationResults.Select(validationResult =>
                       ToastService.AddToastAsync(new ToastModel
                       {
                           Title = "Formulario Incompleto",
                           Message = validationResult.ErrorMessage
                       })
                   ).ToList();
                await Task.WhenAll(toastTasks);
                return false;
            }
            return true;

        }
    }
}