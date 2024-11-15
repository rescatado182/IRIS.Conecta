using ApexCharts;
using IRIS.Frontend.Repositories;
using IRIS.UI.Data;
using IRIS.UI.Icons;
using IRIS.UI.Models;
using IRIS.UI.Models.List;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using TabBlazor;
using TabBlazor.Services;

namespace IRIS.UI.Pages.Masters.User
{
    public partial class UserProfile
    {
        [Inject] private IModalService ModalService { get; set; }
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; }

        private UserProfileVM userProfile = new UserProfileVM();

        [Inject]  IJSRuntime JSRuntime { get; set; }

        private EnumDocumentType selectedDocumentType;
        private List<EnumDocumentType> enumDocumentType = new List<EnumDocumentType>();

        private List<CountryVM> countries = new List<CountryVM>();
        private List<StateVM> states = new List<StateVM>();
        private List<CityVM> cities = new List<CityVM>();

        private CountryVM selectedCountryResidence;


        protected override async Task OnInitializedAsync()
        {

        }

        private async Task UpdateProfile()
        {
            //var responseHttp = await Repository.PutAsync("/users/profile", userProfileVM);
            //if (responseHttp.Error)
            //{
            //    var message = await responseHttp.GetErrorMessageAsync();

            //}
            await ShowInfoModal();

            return;
        }

        private async Task<IEnumerable<CountryVM>> SearchCountries(string searchText)
        {
            return countries.Where(c => c.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task<IEnumerable<StateVM>> SearchSates(string searchText)
        {
            return states.Where(s => s.CountryId == userProfile.BornCountryId && s.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task<IEnumerable<CityVM>> SearchCities(string searchText)
        {
            return cities.Where(ci => ci.StateId == userProfile.BornStateId && ci.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task<IEnumerable<StateVM>> SearchSatesResidence(string searchText)
        {
            selectedCountryResidence = countries.FirstOrDefault(c => c.Id == 48);
            return states.Where(s => s.CountryId == selectedCountryResidence?.Id && s.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task<IEnumerable<CityVM>> SearchCitiesResidence(string searchText)
        {
            return cities.Where(ci => ci.StateId == userProfile.ResidenceStateId && ci.Name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task OnItemSelectedBornCountry(CountryVM country)
        {

            userProfile.BornCountry = country;
            userProfile.BornCountryId = country?.Id ?? 0;


            userProfile.BornState = null;
            userProfile.BornStateId = 0;
            userProfile.BornCity = null;
            userProfile.BornCityId = 0;

            await Task.CompletedTask;
        }


        private async Task OnItemSelectedBornState(StateVM state)
        {

            userProfile.BornState = state;
            userProfile.BornStateId = state?.Id ?? 0;

            userProfile.BornCity = null;
            userProfile.BornCityId = 0;

            await Task.CompletedTask;
        }

        private async Task OnItemSelectedBornCity(CityVM city)
        {

            userProfile.BornCity = city;
            userProfile.BornCityId = city?.Id ?? 0;

            await Task.CompletedTask;
        }

        private async Task OnItemSelectedResidenceState(StateVM state)
        {

            userProfile.StateResidence = state;
            userProfile.ResidenceStateId = state?.Id ?? 0;

            userProfile.CityResidence = null;
            userProfile.ResidenceCityId = 0;

            await Task.CompletedTask;
        }

        private async Task OnItemSelectedResidenceCity(CityVM city)
        {

            userProfile.CityResidence = city;
            userProfile.ResidenceCityId = city?.Id ?? 0;

            await Task.CompletedTask;
        }


        protected async Task ShowInfoModal()
        {
            await ModalService.ShowDialogAsync(new TabBlazor.Components.Modals.DialogOptions
            {
                MainText = "Información Actualizada",
                SubText = "La información de tu perfil ha sido actualizada correctamente",
                IconType = TablerIcons.Info_circle,
                CancelText = "",
                StatusColor = TablerColor.Primary
            });
        }


    }
}