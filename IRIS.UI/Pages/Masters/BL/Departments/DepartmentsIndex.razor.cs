using IRIS.Frontend.Repositories;
using IRIS.UI.Data;
using IRIS.UI.Icons;
using IRIS.UI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using System.Net;
using TabBlazor;
using TabBlazor.Components.Modals;
using TabBlazor.Services;

namespace IRIS.UI.Pages.Masters.BL.Departments
{
    public partial class DepartmentsIndex : ComponentBase
    {

        [Inject] TablerService TablerService { get; set; }
        [Inject] IModalService ModalService { get; set; }
        [Inject] private IRepository Repository { get; set; } = null!;
        public List<DepartmentsVM>? departments { get; set; }
        public List<FacultyVM>? faculties { get; set; }

        FacultyVM selectedFaculty;

        private TableEditMode tableEditMode;






        protected override async Task OnInitializedAsync()
        {

            await ListAsyncFaculties();
            await ListAsync();

        }


        private async Task<bool> ListAsync()
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

        private async Task CreateAsync(DepartmentsVM department)
        {

            department.Faculty = (selectedFaculty = faculties.FirstOrDefault(f => f.Id == department.FacultyId)) != null ? selectedFaculty : department.Faculty;
         

            var responseHttp = await Repository.PostAsync("/api/Departments", department);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await ShowDialog($"Error: {message}");

            }
            return;

        }

        private async Task DeleteAsync(DepartmentsVM department)
        {

            var responseHttp = await Repository.DeleteAsync<DepartmentsVM>($"api/Departments/{department.Id}");
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    var mensajeError = await responseHttp.GetErrorMessageAsync();
                    await ShowDialog($"Error: {mensajeError}");
                }
                return;
            }
        }

        private async Task EditAsync(DepartmentsVM department)
        {
            var responseHttp = await Repository.PutAsync("api/Departments", department);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();

            }

        }


        private Task<DepartmentsVM> AddItem()
        {
            //return Task.FromResult(new DepartmentsVM());
            return Task.FromResult(new DepartmentsVM
            {
                Faculty = new FacultyVM
                {
                    FacultyName = selectedFaculty != null ? selectedFaculty.FacultyName : "New",
                    Id = selectedFaculty != null ? selectedFaculty.Id : 0
                }
            });
        }

        


        private async Task OnItemEdit(DepartmentsVM department)
        {
            department.FacultyId = selectedFaculty.Id;
            await EditAsync(department);
            await ShowDialog($"Item Editado: {department.DepartmentName}");
            await ListAsync();
        }

        private async Task OnItemAdd(DepartmentsVM department)
        {
            department.FacultyId = selectedFaculty.Id;
            await CreateAsync(department);
            await ShowDialog($"Item Añadido: {department.DepartmentName}");
        }

        private async Task OnItemDelete(DepartmentsVM department)
        {
            await DeleteAsync(department);
            await ShowDialog($"Item Eliminado: {department.DepartmentName}");
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

            //convert faculties en List 



            return true;
        }


        private void EditPopupOptions(TableEditPopupOptions<DepartmentsVM> options)
        {
            
            if (options.IsAddInProgress)
            {
                options.Title = "Agregar Nuevo Departamento";
            }
            else
            {
                options.Title = $"Editar Departamento {options.CurrentEditItem.DepartmentName} , { options.CurrentEditItem.FacultyId}";

            }
            options.ModalOptions.Draggable = true;
        }

        private void BeforeEdit(DepartmentsVM department)
        {
            selectedFaculty = faculties.FirstOrDefault(f => f.Id == department.FacultyId);
        }

        private async Task ShowDialog(string title)
        {
            await ModalService.ShowDialogAsync(new DialogOptions
            {
                CancelText = "",
                StatusColor = TablerColor.Primary,
                IconType = @TablerIcons.Info_circle,
                MainText = title
            });
            return;
        }

    }
}