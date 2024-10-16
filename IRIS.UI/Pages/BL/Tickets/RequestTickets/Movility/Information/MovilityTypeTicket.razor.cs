using ApexCharts;
using IRIS.UI.Data;
using IRIS.UI.Models;
using Microsoft.AspNetCore.Components;

namespace IRIS.UI.Pages.BL.Tickets.RequestTickets.Movility.Information
{
    public partial class MovilityTypeTicket : ComponentBase
    {



        private DateTimeOffset selectedInitialDate = DateTimeOffset.Now.AddDays(14).Date;
        private DateTimeOffset selectedFinalDate = DateTimeOffset.Now.AddDays(14).Date;

        private List<CountryVM> countries = new List<CountryVM>();
        public List<StateVM> states = new List<StateVM>();
        public List<CityVM> cities = new List<CityVM>();

        private CountryVM selectedCountry;
        private StateVM selectedState;
        private CityVM selectedCity;

        private List<EnumMovilityType> selectedMovilityType = new List<EnumMovilityType>();
        private List<EnumMovilityType> enumMovilityType = new List<EnumMovilityType>();

        protected override async Task OnInitializedAsync()
        {
            enumMovilityType = Enum.GetValues(typeof(EnumMovilityType)).Cast<EnumMovilityType>().ToList();
            await ListAsyncCountries();


        }

        private string GetMovilityTypeDisplayName(EnumMovilityType movilityType)
        {
            return movilityType.GetDisplayName();
        }

        private async Task<IEnumerable<CountryVM>> SearchCountries(string searchText)
        {
            return countries.Where(c => c.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task<IEnumerable<StateVM>> SearchSates(string searchText)
        {

            return states.Where(s => s.CountryId == selectedCountry?.Id && s.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task<IEnumerable<CityVM>> SearchCities(string searchText)
        {
            return cities.Where(ci => ci.StateId == selectedState?.Id && ci.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
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