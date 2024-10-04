using IRIS.Frontend.Repositories;
using IRIS.UI.Icons;
using IRIS.UI.Models;
using Microsoft.AspNetCore.Components;
using System.Net;
using TabBlazor.Components.Modals;
using TabBlazor;
using TabBlazor.Services;

namespace IRIS.UI.Pages.Masters.BL.RequestTypes
{
    public partial class RequestTypes : ComponentBase
    {
        [Inject] TablerService TablerService { get; set; }
        [Inject] IModalService ModalService { get; set; }
        [Inject] private IRepository Repository { get; set; } = null!;
        public List<RequestTypesVM>? requestTypes { get; set; }

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


            var responseHttp = await Repository.GetAsync<List<RequestTypesVM>>("/api/requesttypes");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();


                return false;
            }
            requestTypes = responseHttp.Response;
            return true;
        }

        private async Task CreateAsync(RequestTypesVM requestType)
        {

            requestType.Department = (selectedDepartment = departments.FirstOrDefault(f => f.Id == requestType.DepartmentId)) != null ? selectedDepartment : requestType.Department;


            var responseHttp = await Repository.PostAsync("/api/requestTypes", requestType);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();


            }

            return;

        }

        private async Task DeleteAsync(RequestTypesVM requestType)
        {

            var responseHttp = await Repository.DeleteAsync<RequestTypesVM>($"api/requestTypes/{requestType.Id}");
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

        private async Task EditAsync(RequestTypesVM requestType)
        {


            var responseHttp = await Repository.PutAsync("api/requestTypes", requestType);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await ShowDialog($"Error: {message}");

            }

        }


        private Task<RequestTypesVM> AddItem()
        {

            
            return Task.FromResult(new RequestTypesVM
            {
                Department = new DepartmentsVM
                {
                    DepartmentName = selectedDepartment != null ? selectedDepartment.DepartmentName : "New",
                    Id = selectedDepartment != null ? selectedDepartment.Id : 0 // O un valor que tenga sentido en tu contexto
                }
            });
        }

        private async Task OnItemEdit(RequestTypesVM requestType)
        {
            requestType.DepartmentId = selectedDepartment.Id;
            await EditAsync(requestType);
            await ShowDialog($"Item Editado: {requestType.RequestName}");
            await ListAsync();
        }

        private async Task OnItemAdd(RequestTypesVM requestType)
        {
            requestType.DepartmentId = selectedDepartment.Id;
            await CreateAsync(requestType);
            await ShowDialog($"Item Añadido: {requestType.RequestName}");
        }

        private async Task OnItemDelete(RequestTypesVM requestType)
        {
            await DeleteAsync(requestType);
            await ShowDialog($"Item Eliminado: {requestType.RequestName}");
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


        private void EditPopupOptions(TableEditPopupOptions<RequestTypesVM> options)
        {

            if (options.IsAddInProgress)
            {
                options.Title = "Agregar Nuevo Tipo de Solicitud";
            }
            else
            {
                options.Title = $"Editar Tipo de Solicitud {options.CurrentEditItem.RequestName} , {options.CurrentEditItem.DepartmentId}";

            }
            options.ModalOptions.Draggable = true;
        }

        private void BeforeEdit(RequestTypesVM requestType)
        {
            selectedDepartment = departments.FirstOrDefault(f => f.Id == requestType.DepartmentId);
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

