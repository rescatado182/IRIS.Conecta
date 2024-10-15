using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;

namespace TabBlazor.Components.Attachments
{
    public partial class InputImg
    {
        private string? imageBase64;


        [Parameter] public string? ImageURL { get; set; }
        [Parameter] public EventCallback<string> ImageSelected { get; set; }

        private async Task OnChange(InputFileChangeEventArgs e)
        {
            var imagenes = e.GetMultipleFiles();

            foreach (var imagen in imagenes)
            {
                var arrBytes = new byte[imagen.Size];
                await imagen.OpenReadStream().ReadAsync(arrBytes);
                string mimeType = imagen.ContentType;
                imageBase64 = Convert.ToBase64String(arrBytes);
                string dataUrl = $"data:{mimeType};base64,{imageBase64}";
                ImageURL = null;
                await ImageSelected.InvokeAsync(dataUrl);
                StateHasChanged();
            }
        }

    }
}