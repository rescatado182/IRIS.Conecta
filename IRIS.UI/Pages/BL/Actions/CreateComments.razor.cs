using Microsoft.AspNetCore.Components;

namespace IRIS.UI.Pages.BL.Actions
{
    public partial class CreateComments
    {
        [Parameter]
        public EventCallback<string> OnSubmit { get; set; }

        [Parameter]
        public bool SendEmail { get; set; }

        private string CommentText { get; set; }
        private bool SendByEmail { get; set; } = false;

        private async Task HandleSubmit()
        {
            // Envía el comentario usando el callback
            await OnSubmit.InvokeAsync(CommentText);

            // Aquí puedes agregar la lógica para enviar el correo si `SendByEmail` es true
        }
        
    }
}