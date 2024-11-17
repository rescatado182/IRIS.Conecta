using IRIS.UI.Icons;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using TabBlazor;
using TabBlazor.Services;

namespace IRIS.UI.Pages.Masters.User
{
    public partial class ChangePassword
    {
        [Inject] private IModalService ModalService { get; set; }
        private PasswordChangeModel passwordModel = new PasswordChangeModel();

        private async Task HandlePasswordChangeAsync()
        {
            await ShowInfoModal();
            // Lógica para cambiar la contraseña
            // Por ejemplo, llamar a un servicio que realice la actualización de la contraseña en la base de datos.
            //Console.WriteLine("Contraseña cambiada exitosamente");
        }

        public class PasswordChangeModel
        {
            [Required(ErrorMessage = "La contraseña actual es obligatoria.")]
            public string CurrentPassword { get; set; }

            [Required(ErrorMessage = "La nueva contraseña es obligatoria.")]
            [MinLength(10, ErrorMessage = "La contraseña debe tener al menos 10 caracteres.")]
            [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{10,}$",
                ErrorMessage = "La contraseña debe contener al menos una mayúscula, una minúscula, un número y un carácter especial.")]
            public string NewPassword { get; set; }

            [Required(ErrorMessage = "Debe confirmar la nueva contraseña.")]
            [Compare("NewPassword", ErrorMessage = "Las contraseñas no coinciden.")]
            public string ConfirmPassword { get; set; }
        }

        protected async Task ShowInfoModal()
        {
            await ModalService.ShowDialogAsync(new TabBlazor.Components.Modals.DialogOptions
            {
                MainText = "Información Actualizada",
                SubText = "Tu contraseña se ha cambiado exitosamente",
                IconType = TablerIcons.Info_circle,
                CancelText = "",
                StatusColor = TablerColor.Primary
            });
        }
    }
}