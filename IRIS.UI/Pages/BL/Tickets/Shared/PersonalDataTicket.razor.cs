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

namespace IRIS.UI.Pages.BL.Tickets.Shared
{
    public partial class PersonalDataTicket : ComponentBase
    {

        private PersonalDataVM personalData = new PersonalDataVM();

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


        public IEnumerable<ValidationResult> ValidatePersonalDataAsync()
        {

            
            var results = new List<ValidationResult>();

            var validationContext = new ValidationContext(personalData, null, null);

            Validator.TryValidateObject(personalData, validationContext, results, true);

            if (personalData is IValidatableObject validatableModel)
                results.AddRange(validatableModel.Validate(validationContext));

            foreach (var validationResult in results)
            {
                Console.WriteLine(validationResult.ErrorMessage);
            }

            return results;

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
            return states.Where(s => s.CountryId == personalData.BornCountryId && s.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task<IEnumerable<CityVM>> SearchCities(string searchText)
        {
            return cities.Where(ci => ci.StateId == personalData.BornStateId && ci.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task<IEnumerable<StateVM>> SearchSatesResidence(string searchText)
        {
            selectedCountryResidence = countries.FirstOrDefault(c => c.Id == 48);

            return states.Where(s => s.CountryId == selectedCountryResidence?.Id && s.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task<IEnumerable<CityVM>> SearchCitiesResidence(string searchText)
        {

            return cities.Where(ci => ci.StateId == personalData.ResidenceStateId && ci.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task OnItemSelectedBorn<T>(T selectedItem)
        {
            if (selectedItem is CityVM city)
            {
                personalData.BornCity = city;
                personalData.BornCityId = city.Id;
            }
            else if (selectedItem is CountryVM country)
            {
                personalData.BornCountry = country;
                personalData.BornCountryId = country.Id;
            }
            else if (selectedItem is StateVM state)
            {
                personalData.BornState = state;
                personalData.BornStateId = state.Id;
            }
        }

        private async Task OnItemSelectedResidence<T>(T selectedItem)
        {
            if (selectedItem is CityVM city)
            {
                personalData.CityResidence = city;
                personalData.ResidenceCityId = city.Id;
            }
            else if (selectedItem is StateVM state)
            {
                personalData.StateResidence = state;
                personalData.ResidenceStateId = state.Id;
            }
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