using DocumentFormat.OpenXml.InkML;
using IRIS.Frontend.Repositories;
using IRIS.UI.Data;
using IRIS.UI.Models;
using IRIS.UI.Pages.Masters.BL.RequestTypes;
using IRIS.UI.Services;
using IRIS.UI.Services.BL;
using Microsoft.AspNetCore.Components;

namespace IRIS.UI.Pages.BL.Tickets.Shared
{
    public partial class PersonalDataTicket : ComponentBase
    {
        private PersonalDataVM personalData = new PersonalDataVM();

        private EnumDocumentType selectedDocumentType;
        private List<EnumDocumentType> enumDocumentType = new List<EnumDocumentType>();

        private List<CountryVM> countries = new List<CountryVM>();
        public List<StateVM> states = new List<StateVM>();
        public List<CityVM> cities = new List<CityVM>();

        //private CountryVM selectedCountry = new CountryVM { Id = -1 };
        //private StateVM selectedState;
        //private CityVM selectedCity;

        private CountryVM selectedCountryResidence;
        //private StateVM selectedStateResidence;
        //private CityVM selectedCityResidence;



        protected override async Task OnInitializedAsync()
        {

            await ListAsyncCountries();
            enumDocumentType = Enum.GetValues(typeof(EnumDocumentType)).Cast<EnumDocumentType>().ToList();

        }

        public bool ValidatePersonalData() {

            if (string.IsNullOrEmpty(personalData.FullName))
            {
                return false; // Los datos no son válidos
            }

            return true; // Los datos son válidos
        }

        private async Task<IEnumerable<CountryVM>> SearchCountries(string searchText)
        {

            return countries.Where(c => c.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task<IEnumerable<StateVM>> SearchSates(string searchText)
        {
            if (personalData.BornCountry != null)            {

                personalData.BornCountryId = personalData.BornCountry.Id;
            }

            return states.Where(s => s.CountryId == personalData.BornCountryId && s.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task<IEnumerable<CityVM>> SearchCities(string searchText)
        {
            if (personalData.BornState != null)
            {

                personalData.BornStateId = personalData.BornState.Id;
            }
            return cities.Where(ci => ci.StateId == personalData.BornStateId && ci.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task<IEnumerable<StateVM>> SearchSatesResidence(string searchText)
        {


            selectedCountryResidence = countries.FirstOrDefault(c => c.Id == 48);

            return states.Where(s => s.CountryId == selectedCountryResidence?.Id && s.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task<IEnumerable<CityVM>> SearchCitiesResidence(string searchText)
        {
            if (personalData.StateResidence != null)
            {

                personalData.ResidenceStateId = personalData.StateResidence.Id;
            }

            return cities.Where(ci => ci.StateId == personalData.ResidenceStateId && ci.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        //private void OnCountryChanged()
        //{
        //    if (personalData.BornCountry != null)
        //    {

        //        personalData.BornCountryId = personalData.BornCountry.Id;
        //    }
        //}
        private async Task<bool> ListAsyncCountries()
        {
            
            countries = Countries.GetCountries();
            states = countries.SelectMany(c => c.States).ToList();
            cities = states.SelectMany(s => s.Cities).ToList();

            return true;
        }

    }
}