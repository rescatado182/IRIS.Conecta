using IRIS.Frontend.Repositories;
using IRIS.UI.Data;
using IRIS.UI.Models;
using IRIS.UI.Pages.Masters.BL.RequestTypes;
using IRIS.UI.Services.BL;
using Microsoft.AspNetCore.Components;

namespace IRIS.UI.Pages.BL.Tickets.Shared
{
    public partial class AcademyDataTicket : ComponentBase
    {

        [Inject] private SearchFacultyServices SearchFaculty { get; set; } = null!;

        private bool isChecked;

        private FacultyVM selectedFaculty;

        private EnumProgramType selectedProgramType;
        private List<EnumProgramType> enumProgramType = new List<EnumProgramType>();

        private List<FacultyVM> faculties = new List<FacultyVM>();

        [Inject] private IRepository Repository { get; set; } = null!;




        protected override async Task OnInitializedAsync()
        {
            enumProgramType = Enum.GetValues(typeof(EnumProgramType)).Cast<EnumProgramType>().ToList();
            await ListAsyncFaculties();
        }

        private async Task<IEnumerable<FacultyVM>> SearchFaculties(string searchText)
        {
            return faculties.Where(f => f.FacultyName.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task<bool> ListAsyncFaculties()
        {


            var responseHttp = await Repository.GetAsync<List<FacultyVM>>("/api/Faculties");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();


                return false;
            }
            faculties = responseHttp.Response;
            return true;
        }
    }
}