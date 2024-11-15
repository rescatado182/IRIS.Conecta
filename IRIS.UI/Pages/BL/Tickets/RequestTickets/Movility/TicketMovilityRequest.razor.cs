using ColorCode.Compilation.Languages;
using IRIS.Frontend.Repositories;
using IRIS.UI.Interfaces;
using IRIS.UI.Models;
using IRIS.UI.Models.List;
using IRIS.UI.Models.Save;
using IRIS.UI.Pages.BL.Tickets.RequestTickets.Movility.Information;
using IRIS.UI.Pages.BL.Tickets.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
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


        
        public JustificationMovilityVM justificationMovility = new JustificationMovilityVM();

        private JustificationMovilityTicket justificationMovilityRef;

        public bool isCompletedJustification = false;


        public RequirementsMovilityVM requirementsMovility = new RequirementsMovilityVM();

        private RequirementsMovilityTicket requirementsMovilityRef;

        public bool isCompletedRequirementsMovility = false;



        


        public List<TicketSaveVM>? ticket { get; set; }

        private TabsOrder tabsOrderRef;


        private bool IsLastTab => tabsOrderRef?.IsLastTab ?? false;

        private bool IsFirstTab => tabsOrderRef?.IsFirstTab ?? true;

        private int? idTicket = null;
        private int personalDataId = 0;
        private int academicDataId = 0; 
        private int movilityTypeId = 0;
        private int requirementsMovilityId = 0;
        private int justificationMovilityId = 0;



        private bool isCompleted2 = false;
        private bool isCompleted3 = false;


        //protected override void OnInitialized()
        //{

        //    requirementsMovilityRef = new RequirementsMovilityTicket();


        //}
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
                        await HandlePersonalDataTabAsync(idTicket, personalData);
                        break;

                    case 1:
                        await HandleAcademyDataTabAsync(idTicket, academyData);
                        break;

                    case 2:
                        await HandleMovilityTypeTabAsync(idTicket, movilityType);
                        break;

                    case 3:
                        await HandleJustificationMovilityTabAsync(idTicket, justificationMovility);
                        break;
                    case 4:
                       
                        await HandleRequirementsTabAsync(idTicket, requirementsMovility);
                        break;

                    default:
                        Console.WriteLine("Invalid tab index");
                        break;
                }

                tabsOrderRef.NextTab(); 
            }
            else
            {
                Console.WriteLine("No se pudo obtener la referencia de TabsOrder");
            }
        }

        private async Task ShowErrorToastAsync(string title, string message)
        {
            await ToastService.AddToastAsync(new ToastModel
            {
                Title = title,
                Message = message,
            });
        }

        private async Task HandlePersonalDataTabAsync(int? idTicket, PersonalDataVM personalData)
        {
            if (!await ValidateDataAsync(personalDataRef)) return;

            personalDataId = await personalDataRef.UpdateTicketPersonalDataAsync(idTicket, personalData, personalDataId);
            if (personalDataId == 0)
            {
                await ShowErrorToastAsync("Error Inesperado", "Tuvimos un error al intentar guardar tu solicitud. Intenta nuevamente");
            }
        }
        private async Task HandleAcademyDataTabAsync(int? idTicket, AcademyDataVM academyData)
        {
            if (!await ValidateDataAsync(academyDataRef)) return;

            academicDataId = await academyDataRef.UpdateTicketAcademyDataAsync(idTicket, academyData, academicDataId);
            if (academicDataId == 0)
            {
                await ShowErrorToastAsync("Error Inesperado", "Tuvimos un error al intentar guardar tu solicitud. Intenta nuevamente");
            }

        }

        private async Task HandleMovilityTypeTabAsync(int? idTicket, MovilityTypeVM movilityType)
        {
            if (!await movilityTypeRef.ValidateDatesAsync(movilityType)) return;

            if (!await ValidateDataAsync(movilityTypeRef)) return;

            movilityTypeId = await movilityTypeRef.UpdateTicketMovilityTypeAsync(idTicket, movilityType, movilityTypeId);
            //if (movilityTypeId == 0)
            //{
            //    await ShowErrorToastAsync("Error Inesperado", "Tuvimos un error al intentar guardar tu solicitud. Intenta nuevamente");
            //}


        }

        private async Task HandleRequirementsTabAsync(int? idTicket, RequirementsMovilityVM requirementsMovility)
        {

            if (!await requirementsMovilityRef.ValidateDatesAsync(requirementsMovility)) return;

            if (!await ValidateDataAsync(requirementsMovilityRef)) return;

            requirementsMovilityId = await requirementsMovilityRef.UpdateTicketRequirementsMovilityAsync(idTicket, requirementsMovility, requirementsMovilityId);
            //if (requirementsMovilityId == 0)
            //{
            //    await ShowErrorToastAsync("Error Inesperado", "Tuvimos un error al intentar guardar tu solicitud. Intenta nuevamente");
            //}
        }

        private async Task HandleJustificationMovilityTabAsync(int? idTicket, JustificationMovilityVM justificationMovility)
        {
            if (!await justificationMovilityRef.ValidateDatesAsync(justificationMovility)) return;

            if (!await ValidateDataAsync(justificationMovilityRef)) return;

            justificationMovilityId = await justificationMovilityRef.UpdateTicketJustificationMovilityAsync(idTicket, justificationMovility, justificationMovilityId);

        }

        private async Task<int?> CreateTicketAsync()
        {
            object jsonResult;

            var ticket = new TicketSaveVM
            {
                Title = "Movilidad",
                Description = "Movilidad",
                RequestTypeId = 1,
                Status = TicketsStatus.Open,
                UserId = "1001"
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