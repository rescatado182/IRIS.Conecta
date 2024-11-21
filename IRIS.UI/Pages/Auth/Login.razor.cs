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
using IRIS.UI.Interfaces;
using IRIS.UI.Icons;
using IRIS.UI.Models.List;

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

        public EventCallback OnClose { get; set; }

        private EditContext editContext;

        private bool isFormValid => !string.IsNullOrWhiteSpace(loginModel.email) &&
                            !string.IsNullOrWhiteSpace(loginModel.password) &&
                            new EmailAddressAttribute().IsValid(loginModel.email);
        protected override void OnInitialized()
        {
            // Inicializar el EditContext y enlazar el evento OnFieldChanged
            editContext = new EditContext(loginModel);


        }


        private void ElementResized(ResizeObserverEntry resizeObserverEntry)
        {
            containerSize = resizeObserverEntry.ContentRect;
        }

        private async Task HandleCreateRequest()
        {


            var responseHttp = await Repository.PostAsync<LoginVM>("/api/auth/Login", loginModel);

            if (!await ValidateLoginAsync())
            {
                return;
            }

            if (responseHttp.Error)
            {
                // si status code es 400 dcir usuario o contraseña invalida
                if (responseHttp.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.BadRequest || responseHttp.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await ModalService.ShowDialogAsync(new DialogOptions
                    {
                        MainText = "Inicio de Sesión Fallido",
                        SubText = "Usuario o contraseña incorrectos.",
                        IconType = TablerIcons.Message,
                        CancelText = "",
                        StatusColor = TablerColor.Primary
                    });
                    return;
                }
                else
                {

                    var message = await responseHttp.GetErrorMessageAsync();
                    Console.WriteLine(message);

                }
            }
            var resultContent = responseHttp.HttpResponseMessage.Content.ReadAsStringAsync().Result;
                if (responseHttp.Error)
                {
                    var message = await responseHttp.GetErrorMessageAsync();
                    Console.WriteLine(message);

                }
            

            using (var jsonDocument = JsonDocument.Parse(resultContent))
            {
                var token = jsonDocument.RootElement.GetProperty("token").ToString();
                await LoginService.LoginAsync(token);
                if (string.IsNullOrEmpty(token))
                {
                    await ModalService.ShowDialogAsync(new DialogOptions
                    {
                        MainText = "Inicio de Sesión Fallido",
                        SubText = "Usuario o contraseña incorrectos.",
                        IconType = TablerIcons.Message,
                        CancelText = "",
                        StatusColor = TablerColor.Primary
                    });


                }
                else
                {
                    await LoginService.LoginAsync(token);
                    NavigationManager.NavigateTo("/");
                }
            }
        

            
        }


        private async Task<bool> ValidateLoginAsync()
        {
            var validationResults = await ValidateDataAsync();

            if (validationResults.Any())
            {
                // Mostrar mensaje de éxito
                await ModalService.ShowDialogAsync(new DialogOptions
                {
                    MainText = "Valida tus datos",
                    SubText = $"Por favor ingresa tus datos para iniciar sesión",
                    IconType = TablerIcons.Error_404,
                    CancelText = "",
                    StatusColor = TablerColor.Primary
                });

                // Invocar el evento OnClose si está definido
                if (OnClose.HasDelegate)
                {
                    await OnClose.InvokeAsync();
                }

                return false;
            }

            return true;
        }

        public Task<IEnumerable<ValidationResult>> ValidateDataAsync()
        {
            var results = new List<ValidationResult>();
            var validationContext = new ValidationContext(loginModel, null, null);
            Validator.TryValidateObject(loginModel, validationContext, results, true);

            if (loginModel is IValidatableObject validatableModel)
                results.AddRange(validatableModel.Validate(validationContext));

            foreach (var validationResult in results)
            {
                Console.WriteLine(validationResult.ErrorMessage);
            }

            return Task.FromResult<IEnumerable<ValidationResult>>(results);
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