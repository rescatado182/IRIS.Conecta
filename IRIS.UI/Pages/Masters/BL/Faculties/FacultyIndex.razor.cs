using DocumentFormat.OpenXml.Spreadsheet;
using IRIS.Frontend.Repositories;
using IRIS.UI.Icons;
using IRIS.UI.Models;
using Microsoft.AspNetCore.Components;
using System.Net;
using TabBlazor;
using TabBlazor.Components.Modals;
using TabBlazor.Services;

namespace IRIS.UI.Pages.Masters.BL.Faculties
{
    public partial class FacultyIndex : ComponentBase
    {

        [Inject] TablerService TablerService { get; set; }
        [Inject] IModalService ModalService { get; set; }
        [Inject] private IRepository Repository { get; set; } = null!;
        [Parameter] public bool ConfirmDelete { get; set; } = true;
        public List<FacultiesVM>? faculties { get; set; }

        private TableEditMode tableEditMode;




        protected override async Task OnInitializedAsync()
        {


            await ListAsync();

        }


        private async Task<bool> ListAsync()
        {


            var responseHttp = await Repository.GetAsync<List<FacultiesVM>>("/api/Faculties");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();


                return false;
            }
            faculties = responseHttp.Response;
            return true;
        }

        private async Task CreateAsync(FacultiesVM faculty)
        {
            var responseHttp = await Repository.PostAsync("/api/faculties", faculty);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();


            }

            return;

        }

        private async Task DeleteAsync(FacultiesVM faculty)
        {

            var responseHttp = await Repository.DeleteAsync<FacultiesVM>($"api/faculties/{faculty.Id}");
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

        private async Task EditAsync(FacultiesVM faculty)
        {
            var responseHttp = await Repository.PutAsync("/api/faculties", faculty);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();

            }

        }




        private Task<FacultiesVM> AddItem()
        {
            return Task.FromResult(new FacultiesVM());
        }

        private async Task OnItemEdit(FacultiesVM faculty)
        {
            await EditAsync(faculty);
            await ShowDialog($"Item Editado: {faculty.FacultyName}");
        }

        private async Task OnItemAdd(FacultiesVM faculty)
        {
            await CreateAsync(faculty);
            await ShowDialog($"Item Añadido: {faculty.FacultyName}");
        }

        private async Task OnItemDelete(FacultiesVM faculty)
        {
            await DeleteAsync(faculty);
            await ShowDialog($"Item Eliminado: {faculty.FacultyName}");
        }



        private void EditPopupOptions(TableEditPopupOptions<FacultiesVM> options)
        {
            if (options.IsAddInProgress)
            {
                options.Title = "Agregar Nueva Facultad";
            }
            else
            {
                options.Title = $"Editar Facultad {options.CurrentEditItem.FacultyName}";
            }
            options.ModalOptions.Draggable = true;
        }

        private void BeforeEdit(FacultiesVM faculty)
        {
            Console.WriteLine(faculty.Id);

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