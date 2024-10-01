using IRIS.Conecta.Domain.Entities.Masters;
using Microsoft.AspNetCore.Components;
using System.Net;
using TabBlazor.Services;
using TabBlazor;
using IRIS.Frontend.Repositories;

namespace IRIS.UI.Pages.Masters.BL.Faculties
{
    public partial class FacultyIndex
    {
        private Faculty? faculty;
        [Inject] private IRepository Repository { get; set; } = null!;

        [Inject] private ToastService ToastService { get; set; } = null!;

        [Inject] private NavigationManager NavigationManager { get; set; } = null!;

        public List<Faculty>? Faculties { get; set; }
        private ToastOptions toastOptions = new ToastOptions();

        protected override async Task OnInitializedAsync()
        {
            await LoadAsync();

            // Simular una espera de 3 segundos
            await Task.Delay(3000);
        }

        private async Task<bool> LoadAsync()
        {


            var responseHttp = await Repository.GetAsync<List<Faculty>>("/api/Faculties");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await ShowToast(message);

                return false;
            }
            Faculties = responseHttp.Response;
            return true;
        }
        private async Task DeleteAsync(Faculty faculty)
        {

            //var result = await ShowToast($"¿Estas seguro de querer borrar: {faculty.FacultyName}?");

            //var confirm = string.IsNullOrEmpty(result.Value);
            //if (confirm)
            //{
            //    return;
            //}

            //var responseHttp = await Repository.DeleteAsync<Faculty>($"api/faculties/{faculty.Id}");
            //if (responseHttp.Error)
            //{
            //    if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
            //    {
            //        NavigationManager.NavigateTo("/faculties");
            //    }
            //    else
            //    {
            //        var mensajeError = await responseHttp.GetErrorMessageAsync();
            //        await ShowToast(mensajeError);

            //    }
            //    return;
            //}

            await LoadAsync();
            await ShowToast("Registro borrado con éxito.");

        }

        private async Task ShowToast(string message)
        {
            await ToastService.AddToastAsync(new ToastModel { Title = "Toast", SubTitle = "Sub title", Message = message });
        }
        private async Task ShowToastOptions(string message)
        {
            await ToastService.AddToastAsync(new ToastModel
            {
                Title = "Toast options",
                SubTitle = "Many options",
                Message = "This is a toast with options",
                Options = toastOptions
            });
        }
    }
}