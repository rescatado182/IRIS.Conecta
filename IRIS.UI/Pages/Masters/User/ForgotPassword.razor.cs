using IRIS.UI.Icons;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using TabBlazor;
using TabBlazor.Services;

namespace IRIS.UI.Pages.Masters.User
{
    public partial class ForgotPassword
    {


        private ForgotPasswordModel forgotPasswordModel = new ForgotPasswordModel();
        [Inject] private IModalService ModalService { get; set; }

        private class ForgotPasswordModel
        {
            [Required(ErrorMessage = "El correo es obligatorio")]
            [EmailAddress(ErrorMessage = "Correo no válido")]
            public string Email { get; set; }
        }

        private async Task SendLinkForgotAsync()
        {

            // Lógica para enviar enlace de recuperación de contraseña  
            await ShowInfoModal();
        }

        protected async Task ShowInfoModal()
        {
            await ModalService.ShowDialogAsync(new TabBlazor.Components.Modals.DialogOptions
            {
                MainText = "Revisa tu correo",
                SubText = "Hemos enviado un enlace para restablecer tu contraseña. Por favor, revisa tu bandeja de entrada o la carpeta de spam.",
                IconType = TablerIcons.Mailbox,
                CancelText = "",
                StatusColor = TablerColor.Primary
            });
        }
    }
}