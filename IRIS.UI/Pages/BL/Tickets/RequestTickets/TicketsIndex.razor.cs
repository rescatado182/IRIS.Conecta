using IRIS.Frontend.Repositories;
using IRIS.UI.Models;
using Microsoft.AspNetCore.Components;
using TabBlazor.Services;
using TabBlazor;

namespace IRIS.UI.Pages.BL.Tickets.RequestTickets
{
    public partial class TicketsIndex : ComponentBase
    {
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private ToastService ToastService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        public List<FacultyVM>? faculties { get; set; }
        public List<DepartmentsVM>? departments { get; set; }
        public List<RequestTypeVM>? requestTypes { get; set; }

        private FacultyVM selectedFaculty;
        private DepartmentsVM selectedDepartment;
        private RequestTypeVM selectedRequestType;
        private ToastOptions toastOptions = new ToastOptions();
        private bool IsButtonDisabled => selectedFaculty == null || selectedDepartment == null || selectedRequestType == null;

        protected override async Task OnInitializedAsync(){
            
            await ListAsyncFaculties();
            await ListAsyncDepartments();
            await ListAsyncRequestTypes();         
        }

        private async Task<IEnumerable<FacultyVM>> SearchFaculties(string searchText)
        {
            return faculties.Where(f => f.FacultyName.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task<IEnumerable<DepartmentsVM>> SearchDepartments(string searchText)
        {
            return departments.Where(d => d.FacultyId == selectedFaculty?.Id && d.DepartmentName.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }

        private async Task<IEnumerable<RequestTypeVM>> SearchRequestTypes(string searchText)
        {
            return requestTypes.Where(rt => rt.DepartmentId == selectedDepartment?.Id && rt.RequestName.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
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

        private async Task<bool> ListAsyncDepartments()
        {
            var responseHttp = await Repository.GetAsync<List<DepartmentsVM>>("/api/Departments");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                return false;
            }
            departments = responseHttp.Response;
            return true;
        }

        private async Task<bool> ListAsyncRequestTypes()
        {
            var responseHttp = await Repository.GetAsync<List<RequestTypeVM>>("/api/requesttypes");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                return false;
            }
            requestTypes = responseHttp.Response;
            return true;
        }

        private async Task HandleCreateRequest()
        {
            //var redirectPath = RequestTypeService.GetRedirectPath(selectedRequestType?.Name);
            var redirectPath = "/createticket/movility";
            if (!string.IsNullOrEmpty(redirectPath))
            {
                NavigationManager.NavigateTo(redirectPath);
            }
        }

        private async Task ShowToast()
        {

            var options = new ToastOptions
            {
                Delay = toastOptions.Delay,
                ShowHeader = toastOptions.ShowHeader,
                ShowProgress = toastOptions.ShowProgress
            };
            await ToastService.AddToastAsync(new ToastModel
            {

                Title = "Toast options",
                SubTitle = "Many options",
                Message = "This is a toast with options",
                Options = options
            });



        }

    }
}