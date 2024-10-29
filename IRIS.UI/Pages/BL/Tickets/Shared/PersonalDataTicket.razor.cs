using ApexCharts;
using DocumentFormat.OpenXml.InkML;
using IRIS.Frontend.Repositories;
using IRIS.UI.Data;
using IRIS.UI.Models;
using IRIS.UI.Pages.Masters.BL.RequestTypes;
using IRIS.UI.Services;
using IRIS.UI.Services.BL;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel.DataAnnotations;
using TabBlazor.Services;
using TabBlazor;
using IRIS.UI.Pages.BL.Tickets.RequestTickets.Movility;
using System.Diagnostics.Metrics;
using IRIS.UI.Models;
using IRIS.UI.Interfaces;

namespace IRIS.UI.Pages.BL.Tickets.Shared
{
    public partial class PersonalDataTicket : ComponentBase, IValidateData
    {
        [Inject] TicketMovilityRequest MovilityRequestState { get; set; }

        //private PersonalDataVM personalData = new PersonalDataVM();


        private EnumDocumentType selectedDocumentType;
        private List<EnumDocumentType> enumDocumentType = new List<EnumDocumentType>();

        private List<CountryVM> countries = new List<CountryVM>();
        private List<StateVM> states = new List<StateVM>();
        private List<CityVM> cities = new List<CityVM>();

        private CountryVM selectedCountryResidence;

        protected override async Task OnInitializedAsync()
        {
            await ListAsyncCountries();
            enumDocumentType = Enum.GetValues(typeof(EnumDocumentType)).Cast<EnumDocumentType>().ToList();
        }



        public Task<IEnumerable<ValidationResult>> ValidateDataAsync()
        {
            var results = new List<ValidationResult>();
            var validationContext = new ValidationContext(MovilityRequestState.personalData, null, null);
            Validator.TryValidateObject(MovilityRequestState.personalData, validationContext, results, true);

            if (MovilityRequestState.personalData is IValidatableObject validatableModel)
                results.AddRange(validatableModel.Validate(validationContext));

            foreach (var validationResult in results)
            {
                Console.WriteLine(validationResult.ErrorMessage);
            }

            return Task.FromResult<IEnumerable<ValidationResult>>(results);
        }

        private void SaveDataToDatabase()
        {
            // Aquí es donde iría la lógica para guardar los datos en la base de datos
            Console.WriteLine("Datos guardados correctamente");
        }

        private void HandleValidSubmit()
        {
            // Si el formulario es válido, puede proceder a guardar los datos en la base de datos
            SaveDataToDatabase();
            Console.WriteLine("Datos guardados correctamente");
        }

        private async Task<IEnumerable<CountryVM>> SearchCountries(string searchText)
        {
            return countries.Where(c => c.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }    

        private async Task<IEnumerable<StateVM>> SearchSates(string searchText)
        {
            return states.Where(s => s.CountryId == MovilityRequestState.personalData.BornCountryId && s.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task<IEnumerable<CityVM>> SearchCities(string searchText)
        {
            return cities.Where(ci => ci.StateId == MovilityRequestState.personalData.BornStateId && ci.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task<IEnumerable<StateVM>> SearchSatesResidence(string searchText)
        {
            selectedCountryResidence = countries.FirstOrDefault(c => c.Id == 48);
            return states.Where(s => s.CountryId == selectedCountryResidence?.Id && s.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task<IEnumerable<CityVM>> SearchCitiesResidence(string searchText)
        {
            return cities.Where(ci => ci.StateId == MovilityRequestState.personalData.ResidenceStateId && ci.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task OnItemSelectedBornCountry(CountryVM country) {

            MovilityRequestState.personalData.BornCountry = country;
            MovilityRequestState.personalData.BornCountryId = country?.Id ?? 0;


            MovilityRequestState.personalData.BornState = null;
            MovilityRequestState.personalData.BornStateId = 0;
            MovilityRequestState.personalData.BornCity = null;
            MovilityRequestState.personalData.BornCityId = 0;
            
            await Task.CompletedTask;
        }


        private async Task OnItemSelectedBornState(StateVM state)
        {

            MovilityRequestState.personalData.BornState = state;
            MovilityRequestState.personalData.BornStateId = state?.Id ?? 0;

            MovilityRequestState.personalData.BornCity = null;
            MovilityRequestState.personalData.BornCityId = 0;

            await Task.CompletedTask;
        }

        private async Task OnItemSelectedBornCity(CityVM city)
        {

            MovilityRequestState.personalData.BornCity = city;
            MovilityRequestState.personalData.BornCityId = city?.Id ?? 0;

            await Task.CompletedTask;
        }

        private async Task OnItemSelectedResidenceState(StateVM state)
        {

            MovilityRequestState.personalData.StateResidence = state;
            MovilityRequestState.personalData.ResidenceStateId = state?.Id ?? 0;

            MovilityRequestState.personalData.CityResidence = null;
            MovilityRequestState.personalData.ResidenceCityId = 0;

            await Task.CompletedTask;
        }

        private async Task OnItemSelectedResidenceCity(CityVM city)
        {

            MovilityRequestState.personalData.CityResidence = city;
            MovilityRequestState.personalData.ResidenceCityId = city?.Id ?? 0;

            await Task.CompletedTask;
        }



        private async Task<bool> ListAsyncCountries()
        {
            countries = Countries.GetCountries();
            states = countries.SelectMany(c => c.States).ToList();
            cities = states.SelectMany(s => s.Cities).ToList();
            return true;
        }


    }
}