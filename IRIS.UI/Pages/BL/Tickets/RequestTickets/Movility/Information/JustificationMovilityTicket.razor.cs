using IRIS.Frontend.Repositories;
using IRIS.UI.Models.List;
using IRIS.UI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using TabBlazor.Services;
using IRIS.UI.Models.Save;
using IRIS.UI.Interfaces;
using TabBlazor;
using DocumentFormat.OpenXml.Spreadsheet;
using IRIS.UI.AuthenticationProviders;

namespace IRIS.UI.Pages.BL.Tickets.RequestTickets.Movility.Information
{
    public partial class JustificationMovilityTicket : IValidateData
    {
        [Inject] TicketMovilityRequest MovilityRequestState { get; set; }
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] public IModalService Modal { get; set; }
        [Inject] public ToastService ToastService { get; set; }


        private bool isChecked;


        private DateTimeOffset selectedDate = DateTimeOffset.Now.AddDays(14).Date;

        private List<EnumTicketRequirements> selectedRequirementTypes = new List<EnumTicketRequirements>();

        public async Task<bool> ValidateDatesAsync(JustificationMovilityVM justificationMovility)
        {

            justificationMovility.DeliveryDate = DateOnly.FromDateTime(selectedDate.DateTime);


            //start date must be greater than today
            if (justificationMovility.DeliveryDate <= DateOnly.FromDateTime(DateTime.Now))
            {
                await ToastService.AddToastAsync(new ToastModel { Title = "Fecha entrega compromisos", Message = "La Fecha entrega compromisos debe ser mayor a la fecha actual" });
                return false;
            }

            MovilityRequestState.justificationMovility.DeliveryDate = justificationMovility.DeliveryDate;

            return true;
        }


        public Task<IEnumerable<ValidationResult>> ValidateDataAsync()
        {
            var results = new List<ValidationResult>();

            try
            {
   
                var validationContext = new ValidationContext(MovilityRequestState.justificationMovility, null, null);
                Validator.TryValidateObject(MovilityRequestState.justificationMovility, validationContext, results, true);

                if (MovilityRequestState.justificationMovility is IValidatableObject validatableModel)
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


        public async Task<int> UpdateTicketJustificationMovilityAsync(int? idTicket, JustificationMovilityVM justificationMovility, int justicationMovilityId, string userId)
        {
            var updatedJustificationMovility = CreateUpdatedJustificatioMovility(idTicket, justificationMovility, userId);

            LogJsonPayload(updatedJustificationMovility);

            var responseHttp = await Repository.PutAsync("/api/tickets/updateTicket", updatedJustificationMovility);

            if (responseHttp.Error)
            {
                await LogAndShowErrorAsync(responseHttp);
                return 0;
            }

            return await GetUpdatedEntityIdAsync(responseHttp) ?? 0;
        }

        private JustificationMovilitySaveVM CreateUpdatedJustificatioMovility(int? idTicket, JustificationMovilityVM justificationMovility, string userId)
        {

            return new JustificationMovilitySaveVM
            {
                Id = idTicket.Value,
                AgreementName = MovilityRequestState.justificationMovility.AgreementName,
                Description = MovilityRequestState.justificationMovility.Description,
                IsAgreement = MovilityRequestState.justificationMovility.IsAgreement,
                Results = MovilityRequestState.justificationMovility.Results,
                DeliveryDate = MovilityRequestState.justificationMovility.DeliveryDate,
                RequestTypeId = 1,
                Status = TicketsStatus.Open,
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