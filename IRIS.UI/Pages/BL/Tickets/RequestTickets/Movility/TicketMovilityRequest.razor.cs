using ColorCode.Compilation.Languages;
using DocumentFormat.OpenXml.Spreadsheet;
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
using System.Security.Claims;
using System.Text.Json;
using System.Web.Mvc;
using TabBlazor;
using TabBlazor.Components.Modals;
using TabBlazor.Services;

using Microsoft.AspNetCore.Components.Authorization;
using IRIS.UI.AuthenticationProviders;

namespace IRIS.UI.Pages.BL.Tickets.RequestTickets.Movility
{
    public partial class TicketMovilityRequest
    {

        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] public IModalService Modal { get; set; }
        [Inject] public ToastService ToastService { get; set; }

        [Inject] public AuthenticationProviderJWT AuthenticationProviderJWT { get; set; }



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

        public string userId;

        private async Task PreviousStepAsync()
        {
            tabsOrderRef.PreviousTab();
        }

        private async Task NextStepAsync()
        {



            userId = await AuthenticationProviderJWT.GetUserIdAsync();
            


            //crear ticket
            if (idTicket == null)
            {
                idTicket = await CreateTicketAsync(userId);
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
                        await HandlePersonalDataTabAsync(idTicket, personalData, userId);
                        break;

                    case 1:
                        await HandleAcademyDataTabAsync(idTicket, academyData, userId);
                        break;

                    case 2:
                        await HandleMovilityTypeTabAsync(idTicket, movilityType, userId);
                        break;

                    case 3:
                        await HandleJustificationMovilityTabAsync(idTicket, justificationMovility, userId);
                        break;
                    case 4:
                       
                        await HandleRequirementsTabAsync(idTicket, requirementsMovility, userId);
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

        private async Task HandlePersonalDataTabAsync(int? idTicket, PersonalDataVM personalData, string userId)
        {
            if (!await ValidateDataAsync(personalDataRef)) return;

            personalDataId = await personalDataRef.UpdateTicketPersonalDataAsync(idTicket, personalData, personalDataId, userId);
            if (personalDataId == 0)
            {
                await ShowErrorToastAsync("Error Inesperado", "Tuvimos un error al intentar guardar tu solicitud. Intenta nuevamente");
                return;
            }
            isCompletedPersonalData = true;
        }
        private async Task HandleAcademyDataTabAsync(int? idTicket, AcademyDataVM academyData, string userId)
        {
            if (!await ValidateDataAsync(academyDataRef)) return;

            academicDataId = await academyDataRef.UpdateTicketAcademyDataAsync(idTicket, academyData, academicDataId, userId);
            if (academicDataId == 0)
            {
                await ShowErrorToastAsync("Error Inesperado", "Tuvimos un error al intentar guardar tu solicitud. Intenta nuevamente");
                return;
            }
            isCompletedAcademyData = true;
        }

        private async Task HandleMovilityTypeTabAsync(int? idTicket, MovilityTypeVM movilityType, string userId)
        {
            if (!await movilityTypeRef.ValidateDatesAsync(movilityType)) return;

            if (!await ValidateDataAsync(movilityTypeRef)) return;

            movilityTypeId = await movilityTypeRef.UpdateTicketMovilityTypeAsync(idTicket, movilityType, movilityTypeId, userId);

            isCompletedMovilityType = true;
            //if (movilityTypeId == 0)
            //{
            //    await ShowErrorToastAsync("Error Inesperado", "Tuvimos un error al intentar guardar tu solicitud. Intenta nuevamente");
            //}


        }

        private async Task HandleRequirementsTabAsync(int? idTicket, RequirementsMovilityVM requirementsMovility, string userId)
        {

            if (!await requirementsMovilityRef.ValidateDatesAsync(requirementsMovility)) return;

            if (!await ValidateDataAsync(requirementsMovilityRef)) return;

            requirementsMovilityId = await requirementsMovilityRef.UpdateTicketRequirementsMovilityAsync(idTicket, requirementsMovility, requirementsMovilityId, userId);

            isCompletedRequirementsMovility = true;
            //if (requirementsMovilityId == 0)
            //{
            //    await ShowErrorToastAsync("Error Inesperado", "Tuvimos un error al intentar guardar tu solicitud. Intenta nuevamente");
            //}
        }

        private async Task HandleJustificationMovilityTabAsync(int? idTicket, JustificationMovilityVM justificationMovility, string userId)
        {
            if (!await justificationMovilityRef.ValidateDatesAsync(justificationMovility)) return;

            if (!await ValidateDataAsync(justificationMovilityRef)) return;

            justificationMovilityId = await justificationMovilityRef.UpdateTicketJustificationMovilityAsync(idTicket, justificationMovility, justificationMovilityId, userId);

            isCompletedJustification = true;
        }

        private async Task<int?> CreateTicketAsync(string userId)
        {
            object jsonResult;

            var ticket = new TicketSaveVM
            {
                Title = "Movilidad",
                Description = "Movilidad",
                RequestTypeId = 1,
                Status = TicketsStatus.Open,
                UserId = userId,
                CreateDate = DateOnly.FromDateTime(DateTime.Now)

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