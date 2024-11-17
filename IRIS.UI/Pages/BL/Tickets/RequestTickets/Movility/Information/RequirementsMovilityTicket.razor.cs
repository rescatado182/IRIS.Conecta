using IRIS.Frontend.Repositories;
using IRIS.UI.Models;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using TabBlazor.Services;
using TabBlazor;
using IRIS.UI.Interfaces;
using IRIS.UI.Models.List;
using DocumentFormat.OpenXml;

namespace IRIS.UI.Pages.BL.Tickets.RequestTickets.Movility.Information
{
    public partial class RequirementsMovilityTicket : ComponentBase, IValidateData
    {
        [Inject] TicketMovilityRequest MovilityRequestState { get; set; }
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] public ToastService ToastService { get; set; }

        public string SelectTicketRequirements { get; set; }

        private EnumTicketRequirements _selectedRequirements;

        private DateTimeOffset selectedInitialDate = DateTimeOffset.Now.AddDays(14).Date;
        private DateTimeOffset selectedFinalDate = DateTimeOffset.Now.AddDays(14).Date;

        private List<EnumTicketRequirements> selectedRequirementTypes = new List<EnumTicketRequirements>();
        private List<EnumTicketRequirements> enumRequirementsTypes = new List<EnumTicketRequirements>();


        protected override void OnInitialized()
        {
            selectedInitialDate = MovilityRequestState.requirementsMovility.StartDateRequirement != DateOnly.MinValue
                ? new DateTimeOffset(MovilityRequestState.requirementsMovility.StartDateRequirement.ToDateTime(TimeOnly.MinValue))
                : DateTimeOffset.Now;

            selectedFinalDate = MovilityRequestState.requirementsMovility.EndDateRequirement != DateOnly.MinValue
                ? new DateTimeOffset(MovilityRequestState.requirementsMovility.EndDateRequirement.ToDateTime(TimeOnly.MinValue))
                : DateTimeOffset.Now;

            enumRequirementsTypes = Enum.GetValues(typeof(EnumTicketRequirements)).Cast<EnumTicketRequirements>().ToList();
        }
        private string GetRequirementTypesDisplayName(EnumTicketRequirements requirement)
        {
            return requirement.GetDisplayName();
        }

        public async Task<bool> ValidateDatesAsync(RequirementsMovilityVM requirementsMovility)
        {
            requirementsMovility.StartDateRequirement = DateOnly.FromDateTime(selectedInitialDate.DateTime);
            requirementsMovility.EndDateRequirement = DateOnly.FromDateTime(selectedFinalDate.DateTime);

            if (requirementsMovility.StartDateRequirement > requirementsMovility.EndDateRequirement)
            {
                await ToastService.AddToastAsync(new ToastModel { Title = "Fecha Inicio de Movilidad", Message = "La fecha de inicio de Movilidad debe ser menor a la fecha de fin" });
                return false;
            }

            //start date must be greater than today
            if (requirementsMovility.StartDateRequirement < DateOnly.FromDateTime(DateTime.Now))
            {
                await ToastService.AddToastAsync(new ToastModel { Title = "Fecha Inicio de Movilidad", Message = "La fecha de inicio de Movilidad debe ser mayor a la fecha actual" });
                return false;
            }

            MovilityRequestState.requirementsMovility.StartDateRequirement = requirementsMovility.StartDateRequirement;
            MovilityRequestState.requirementsMovility.EndDateRequirement = requirementsMovility.EndDateRequirement;
            return true;
        }

        public Task<IEnumerable<ValidationResult>> ValidateDataAsync()
        {
            var results = new List<ValidationResult>();

            try
            {


                string enumTicketRequirements = Enum.GetName(typeof(EnumTicketRequirements), selectedRequirementTypes);


                MovilityRequestState.requirementsMovility.RequirementsTypesDisplayName = selectedRequirementTypes.Count > 0
                    ? string.Join(", ", selectedRequirementTypes.Select(GetRequirementTypesDisplayName))
                    : string.Empty;

                var validationContext = new ValidationContext(MovilityRequestState.requirementsMovility, null, null);
                Validator.TryValidateObject(MovilityRequestState.requirementsMovility, validationContext, results, true);

                if (MovilityRequestState.requirementsMovility is IValidatableObject validatableModel)
                    results.AddRange(validatableModel.Validate(validationContext));



                foreach (var validationResult in results)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }


                return Task.FromResult<IEnumerable<ValidationResult>>(results);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Task.FromResult<IEnumerable<ValidationResult>>(results);
            }



        }

        public async Task<int> UpdateTicketRequirementsMovilityAsync(int? idTicket, RequirementsMovilityVM requirementsMovility, int requirementsMovilityId, string userId)
        {


            var updatedRequirementsMovility = CreateUpdatedRequirementsMovility(idTicket, requirementsMovility, userId);

            LogJsonPayload(updatedRequirementsMovility);

            var responseHttp = await Repository.PutAsync("/api/tickets/updateTicketByRequirements", updatedRequirementsMovility);

            if (responseHttp.Error)
            {
                await LogAndShowErrorAsync(responseHttp);
                return 0;
            }

            return await GetUpdatedEntityIdAsync(responseHttp) ?? 0;
        }

        private RequirementsMovilitySaveVM CreateUpdatedRequirementsMovility(int? idTicket, RequirementsMovilityVM RequirementsMovility, string userId)
        {



            return new RequirementsMovilitySaveVM
            {
                Id = idTicket.Value,
                Status = TicketsStatus.Open,
                StartDateRequirement = MovilityRequestState.requirementsMovility.StartDateRequirement,
                EndDateRequirement = MovilityRequestState.requirementsMovility.EndDateRequirement,
                TicketRequirements = string.Join(",", selectedRequirementTypes),
                Total = MovilityRequestState.requirementsMovility.Total,
                UserId = userId,
                ManagerUserId = "1001"
            };
        }

        private void LogJsonPayload(object data)
        {
            string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(jsonString);
        }

        private async Task LogAndShowErrorAsync(HttpResponseWrapper<object> responseHttp)
        {
            var message = await responseHttp.GetErrorMessageAsync();
            Console.WriteLine(message);
        }

        private async Task<int?> GetUpdatedEntityIdAsync(HttpResponseWrapper<object> responseHttp)
        {
            var resultContent = await responseHttp.HttpResponseMessage.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(resultContent)) return null;

            using var jsonDocument = JsonDocument.Parse(resultContent);
            return jsonDocument.RootElement.TryGetProperty("id", out var idElement)
                ? idElement.GetInt32()
                : (int?)null;
        }
    }
}