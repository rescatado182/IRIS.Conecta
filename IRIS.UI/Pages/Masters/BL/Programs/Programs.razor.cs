using IRIS.Frontend.Repositories;
using IRIS.UI.Icons;
using IRIS.UI.Models;
using Microsoft.AspNetCore.Components;
using System.Net;
using TabBlazor.Components.Modals;
using TabBlazor.Services;
using TabBlazor;

namespace IRIS.UI.Pages.Masters.BL.Programs
{
    public partial class Programs
    {
        [Inject] TablerService TablerService { get; set; }
        [Inject] IModalService ModalService { get; set; }
        [Inject] private IRepository Repository { get; set; } = null!;
        public List<ProgramVM>? programs { get; set; }
        public List<DepartmentsVM>? departments { get; set; }

        DepartmentsVM selectedDepartment;

        private TableEditMode tableEditMode;



        protected override async Task OnInitializedAsync()
        {

            await ListAsyncDepartments();
            await ListAsync();

        }


        private async Task<bool> ListAsync()
        {


            var responseHttp = await Repository.GetAsync<List<ProgramVM>>("/api/programs");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();


                return false;
            }
            programs = responseHttp.Response;
            return true;
        }

        private async Task CreateAsync(ProgramVM program)
        {

            //program.Department = (selectedDepartment = departments.FirstOrDefault(f => f.Id == program.DepartmentId)) != null ? selectedDepartment : program.Department;


            //var responseHttp = await Repository.PostAsync("/api/programs", program);
            //if (responseHttp.Error)
            //{
            //    var message = await responseHttp.GetErrorMessageAsync();


            //}

            return;

        }

        private async Task DeleteAsync(ProgramVM program)
        {

            var responseHttp = await Repository.DeleteAsync<ProgramVM>($"api/programs/{program.Id}");
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

        private async Task EditAsync(ProgramVM program)
        {


            var responseHttp = await Repository.PutAsync("api/programs", program);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await ShowDialog($"Error: {message}");

            }

        }


        private Task<ProgramVM> AddItem()
        {


            return Task.FromResult(new ProgramVM
            {
                //Department = new DepartmentsVM
                //{
                //    DepartmentName = selectedDepartment != null ? selectedDepartment.DepartmentName : "New",
                //    Id = selectedDepartment != null ? selectedDepartment.Id : 0 // O un valor que tenga sentido en tu contexto
                //}
            });
        }

        private async Task OnItemEdit(ProgramVM program)
        {
        //    program.DepartmentId = selectedDepartment.Id;
        //    await EditAsync(program);
        //    await ShowDialog($"Item Editado: {program.RequestName}");
        //    await ListAsync();
        }

        private async Task OnItemAdd(ProgramVM program)
        {
            //program.DepartmentId = selectedDepartment.Id;
            //await CreateAsync(program);
            //await ShowDialog($"Item Añadido: {program.RequestName}");
        }

        private async Task OnItemDelete(ProgramVM program)
        {
            //await DeleteAsync(program);
            //await ShowDialog($"Item Eliminado: {program.RequestName}");
        }

        private async Task<bool> ListAsyncDepartments()
        {


            var responseHttp = await Repository.GetAsync<List<DepartmentsVM>>("/api/departments");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();


                return false;
            }
            departments = responseHttp.Response;

            return true;
        }


        private void EditPopupOptions(TableEditPopupOptions<ProgramVM> options)
        {

            if (options.IsAddInProgress)
            {
                options.Title = "Agregar Nuevo Tipo de Solicitud";
            }
            else
            {
              //  options.Title = $"Editar Tipo de Solicitud {options.CurrentEditItem.RequestName} , {options.CurrentEditItem.DepartmentId}";

            }
            options.ModalOptions.Draggable = true;
        }

        private void BeforeEdit(ProgramVM program)
        {
          //  selectedDepartment = departments.FirstOrDefault(f => f.Id == program.DepartmentId);
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

