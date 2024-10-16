using IRIS.Frontend.Repositories;
using IRIS.UI.Models;
using Microsoft.AspNetCore.Components;

namespace IRIS.UI.Services.BL
{
    public class SearchFacultyServices
    {
        public List<FacultyVM> faculties { get; set; }
        [Inject] public IRepository Repository { get; set; }

        public SearchFacultyServices(IRepository repository)
        {
            Repository = repository;
        }



        public async Task<List<FacultyVM>> GetListAsyncFaculties()
        {
            var responseHttp = await Repository.GetAsync<List<FacultyVM>>("/api/Faculties");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                return null;
            }
            faculties = responseHttp.Response;
            return faculties;
        }
    }
}
