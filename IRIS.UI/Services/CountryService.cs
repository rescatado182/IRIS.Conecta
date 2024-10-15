using IRIS.Frontend.Repositories;
using IRIS.UI.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace IRIS.UI.Services
{
    public class CountryService
    {
        public List<CountryVM> countries { get; set; }

        [Inject] public IRepository Repository { get; set; }

        public CountryService(IRepository repository)
        {
            Repository = repository;
        }

        public async Task<List<CountryVM>> GetListAsyncCountries()
        {


            var responseHttp = await Repository.GetAsync<List<CountryVM>>("/api/Countries");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                return null;
            }
            countries = responseHttp.Response;
            return countries;
        }


    }

    
}
