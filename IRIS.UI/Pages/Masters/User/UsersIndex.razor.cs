using IRIS.Frontend.Repositories;
using IRIS.UI.Icons;
using Microsoft.AspNetCore.Components;
using System.Net;
using TabBlazor.Components.Modals;
using TabBlazor.Services;
using TabBlazor;
using IRIS.UI.Models.Save;

namespace IRIS.UI.Pages.Masters.User
{
    public partial class UsersIndex : ComponentBase
    {
        [Inject] TablerService TablerService { get; set; } = null!;
        [Inject] IModalService ModalService { get; set; } = null!;
        [Inject] private IRepository Repository { get; set; } = null!;
        public List<UserVM>? users { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await ListAsync();
        }

        private async Task<bool> ListAsync()
        {
            var responseHttp = await Repository.GetAsync<List<UserVM>>("/api/users/getstudents");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                return false;
            }

            users = responseHttp.Response;
            return true;
        }

        private async Task CreateAsync(UserVM user)
        {
            var responseHttp = await Repository.PostAsync("/api/auth/register", user);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
            }
        }

        //private async Task DeleteAsync(UserVM user)
        //{
        //    var responseHttp = await Repository.DeleteAsync<UserVM>($"/api/auth/users/{user.UserName}");
        //    if (responseHttp.Error)
        //    {
        //        if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
        //        {
        //            var message = await responseHttp.GetErrorMessageAsync();
        //            await ShowDialog($"Error: {message}");
        //        }
        //        return;
        //    }
        //}

        //private async Task EditAsync(UserVM user)
        //{
        //    var responseHttp = await Repository.PutAsync("/api/auth/users", user);
        //    if (responseHttp.Error)
        //    {
        //        var message = await responseHttp.GetErrorMessageAsync();
        //    }
        //}

        private Task<UserVM> AddItem()
        {
            return Task.FromResult(new UserVM());
        }

        private async Task OnItemEdit(UserVM user)
        {
           // await EditAsync(user);
            await ShowDialog($"Usuario Editado: {user.UserName}");
        }

        private async Task OnItemAdd(UserVM user)
        {
            await CreateAsync(user);
            await ShowDialog($"Usuario Añadido: {user.UserName}");
        }

        private async Task OnItemDelete(UserVM user)
        {
         //   await DeleteAsync(user);
            await ShowDialog($"Usuario Eliminado: {user.UserName}");
        }

        private void EditPopupOptions(TableEditPopupOptions<UserVM> options)
        {
            options.Title = options.IsAddInProgress ? "Agregar Nuevo Usuario" : $"Editar Usuario {options.CurrentEditItem.UserName}";
            options.ModalOptions.Draggable = true;
        }

        private async Task ShowDialog(string title)
        {
            await ModalService.ShowDialogAsync(new DialogOptions
            {
                CancelText = "",
                StatusColor = TablerColor.Primary,
                IconType = TablerIcons.Info_circle,
                MainText = title
            });
        }
    }
}
