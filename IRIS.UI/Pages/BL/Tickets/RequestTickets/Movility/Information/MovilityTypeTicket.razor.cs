using ApexCharts;
using IRIS.Frontend.Repositories;
using IRIS.UI.Data;
using IRIS.UI.Interfaces;
using IRIS.UI.Models;
using IRIS.UI.Models.Save;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;
using TabBlazor;
using TabBlazor.Services;
using static TabBlazor.EnumHelper;

namespace IRIS.UI.Pages.BL.Tickets.RequestTickets.Movility.Information
{
    public partial class MovilityTypeTicket : ComponentBase, IValidateData
    {

        [Inject] TicketMovilityRequest MovilityRequestState { get; set; }
        [Inject] public ToastService ToastService { get; set; }
        [Inject] private IRepository Repository { get; set; } = null!;


  private DateTimeOffset selectedInitialDate;
private DateTimeOffset selectedFinalDate;



        private EnumDocumentType selectedMovilityType;
        public List<SelectItem> enumMovilityType { get; set; }

        private List<CountryVM> countries = new List<CountryVM>();
        public List<StateVM> states = new List<StateVM>();
        public List<CityVM> cities = new List<CityVM>();

        private CountryVM selectedCountry;
        private StateVM selectedState;
        private CityVM selectedCity;


        protected override async Task OnInitializedAsync()
        {
            selectedInitialDate = MovilityRequestState.movilityType.StartDate != null && MovilityRequestState.movilityType.StartDate != DateOnly.MinValue
                ? new DateTimeOffset(MovilityRequestState.movilityType.StartDate.ToDateTime(TimeOnly.MinValue))
                : DateTimeOffset.Now;

            selectedFinalDate = MovilityRequestState.movilityType.EndDate != null && MovilityRequestState.movilityType.EndDate != DateOnly.MinValue
                ? new DateTimeOffset(MovilityRequestState.movilityType.EndDate.ToDateTime(TimeOnly.MinValue))
                : DateTimeOffset.Now;
            enumMovilityType = EnumHelper.GetEnumSelectItems<EnumMovilityType>();
            //enumMovilityType = EnumHelper.GetList<EnumMovilityType>();


            await ListAsyncCountries();


        }

        //private string GetMovilityTypeDisplayName(EnumMovilityType EnumMovilityType)
        //{
        //    return EnumMovilityType.GetDisplayName();
        //}

        private EnumMovilityType ConvertToEnum(SelectItem item)
        {
            return (EnumMovilityType)item.Value;
        }

        private async Task<IEnumerable<CountryVM>> SearchCountries(string searchText)
        {
            return countries.Where(c => c.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task<IEnumerable<StateVM>> SearchSates(string searchText)
        {
            return states.Where(s => s.CountryId == MovilityRequestState.movilityType.DestinationCountryId && s.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task<IEnumerable<CityVM>> SearchCities(string searchText)
        {
            return cities.Where(ci => ci.StateId == MovilityRequestState.movilityType.DestinationStateId && ci.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task<bool> ListAsyncCountries()
        {

            countries = Countries.GetCountries();
            states = countries.SelectMany(c => c.States).ToList();
            cities = states.SelectMany(s => s.Cities).ToList();

            return true;
        }

        private async Task OnItemSelectedDestinationCountry(CountryVM country)
        {

            MovilityRequestState.movilityType.DestinationCountry = country;
            MovilityRequestState.movilityType.DestinationCountryId = country?.Id ?? 0;
                           

            MovilityRequestState.movilityType.DestinationState = null;
            MovilityRequestState.movilityType.DestinationStateId = 0;
            MovilityRequestState.movilityType.DestinationCity = null;
            MovilityRequestState.movilityType.DestinationCityId = 0;

            await Task.CompletedTask;
        }


        private async Task OnItemSelectedDestinationState(StateVM state)
        {

            MovilityRequestState.movilityType.DestinationState = state;
            MovilityRequestState.movilityType.DestinationStateId = state?.Id ?? 0;

            MovilityRequestState.movilityType.DestinationCity = null;
            MovilityRequestState.movilityType.DestinationCityId = 0;

            await Task.CompletedTask;
        }

        private async Task OnItemSelectedDestinationCity(CityVM city)
        {

            MovilityRequestState.movilityType.DestinationCity = city;
            MovilityRequestState.movilityType.DestinationCityId = city?.Id ?? 0;

            await Task.CompletedTask;
        }


        public async Task<bool> ValidateDatesAsync(MovilityTypeVM movilityType)
        {
            movilityType.StartDate = DateOnly.FromDateTime(selectedInitialDate.DateTime);
            movilityType.EndDate = DateOnly.FromDateTime(selectedFinalDate.DateTime);

            if (movilityType.StartDate > movilityType.EndDate)
            {
                await ToastService.AddToastAsync(new ToastModel { Title = "Fecha Inicio de Movilidad", Message = "La fecha de inicio de Movilidad debe ser menor a la fecha de fin" });
                return false;
            }

            //start date must be greater than today
            if (movilityType.StartDate < DateOnly.FromDateTime(DateTime.Now))
            {
                await ToastService.AddToastAsync(new ToastModel { Title = "Fecha Inicio de Movilidad", Message = "La fecha de inicio de Movilidad debe ser mayor a la fecha actual" });
                return false;
            }

            MovilityRequestState.movilityType.StartDate = movilityType.StartDate;
            MovilityRequestState.movilityType.EndDate = movilityType.EndDate;
            return true;
        }

        public Task<IEnumerable<ValidationResult>> ValidateDataAsync()
        {
            var results = new List<ValidationResult>();

            try
            {



                
                var validationContext = new ValidationContext(MovilityRequestState.movilityType, null, null);
                Validator.TryValidateObject(MovilityRequestState.movilityType, validationContext, results, true);

                if (MovilityRequestState.movilityType is IValidatableObject validatableModel)
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

        public async Task UpdateTicketMovilityTypeAsync(int? idTicket, MovilityTypeVM movilityType)
        {
            var updatedMovilityType = new MovilityTypeSaveVM
            {
                id = idTicket.Value,
                eventName = MovilityRequestState.movilityType.EventName.ToString(),
                title = MovilityRequestState.movilityType.Title.ToString(),
                status = TicketsStatus.Open,
                movilityType = EnumMovilityType.InstitutionalRepresentation.ToString(),
                country = MovilityRequestState.movilityType.DestinationCountryId > 0
                  ? MovilityRequestState.movilityType.DestinationCountryId.ToString()
                  : string.Empty,
                city = MovilityRequestState.movilityType.DestinationCityId > 0
               ? MovilityRequestState.movilityType.DestinationCityId.ToString()
               : string.Empty,
                phone = MovilityRequestState.movilityType.Phone.ToString(),
                contactData = MovilityRequestState.movilityType.ContactData.ToString(),
                externalInstitution = MovilityRequestState.movilityType.externalInstitution.ToString(),
                startDate = MovilityRequestState.movilityType.StartDate,
                endDate = MovilityRequestState.movilityType.EndDate
            };

            string jsonString = JsonSerializer.Serialize(updatedMovilityType, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(jsonString);

            var responseHttp = await Repository.PutAsync("/api/tickets/updateTicketByMovility", updatedMovilityType);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                Console.WriteLine(message);
            }

        }


    }
}