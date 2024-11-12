using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using TabBlazor.Components.Modals;
using TabBlazor.Services;
using IRIS.UI.Models;
using TabBlazor;
using IRIS.Frontend.Repositories;
using IRIS.UI.Services;
using System.Text.Json;

namespace IRIS.UI.Pages.Auth
{
    public partial class Login
    {
        [Inject] IModalService ModalService { get; set; }

        [Inject] private NavigationManager NavigationManager { get; set; } = null!;

        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private ILoginService LoginService { get; set; } = null!;

        private LoginVM loginModel = new LoginVM();
        private ContentRect containerSize;
        private string widthMessage;
        private string heightMessage;


        private async Task HandleLogin(EditContext context)
        {
            // Lógica básica de autenticación

                var responseHttp = await Repository.PostAsync<LoginVM>("/api/auth/Login", loginModel);
                if (responseHttp.Error)
                {
                    var message = await responseHttp.GetErrorMessageAsync();

                    await ModalService.ShowDialogAsync(new DialogOptions
                    {
                        MainText = "Login Exitoso",
                        SubText = $"Bienvenido!"
                    });
                    return;

                }

                //await LoginService.LoginAsync(responseHttp.Response.t);
                //NavigationManager.NavigateTo("/");



                await ModalService.ShowDialogAsync(new DialogOptions
                {
                    MainText = "Login Fallido",
                    SubText = "Usuario o contraseña incorrectos."
                });
            


        }

        private void ElementResized(ResizeObserverEntry resizeObserverEntry)
        {
            containerSize = resizeObserverEntry.ContentRect;
        }

        private async Task HandleCreateRequest()
        {
            var responseHttp = await Repository.PostAsync<LoginVM>("/api/auth/Login", loginModel);

            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                Console.WriteLine(message);

            }
            var resultContent = responseHttp.HttpResponseMessage.Content.ReadAsStringAsync().Result;

            using (var jsonDocument = JsonDocument.Parse(resultContent))
            {
                var token = jsonDocument.RootElement.GetProperty("token").ToString();
                await LoginService.LoginAsync(token);
                NavigationManager.NavigateTo("/");
            }

        }


        private void WidthResized(ResizeObserverEntry resizeObserverEntry)
        {
            widthMessage = "700";
            //$"Ancho: {resizeObserverEntry?.ContentRect?.Width}";
        }

        private void HeightResized(ResizeObserverEntry resizeObserverEntry)
        {
            heightMessage = $"Altura: {resizeObserverEntry?.ContentRect?.Height}";
        }

    }
}