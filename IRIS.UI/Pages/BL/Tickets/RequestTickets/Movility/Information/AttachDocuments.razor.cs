using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.IO.Compression;
using TabBlazor.Components.Modals;
using TabBlazor.Services;

namespace IRIS.UI.Pages.BL.Tickets.RequestTickets.Movility.Information
{
    public partial class AttachDocuments
    {
        private string? selectedImage;
        private string? imageUrl;

        [Inject] private TablerService tabService { get; set; }
        [Inject] private IJSRuntime JS { get; set; }

        private void ImageSelected(string imagenBase64)
        {

            imageUrl = imagenBase64;


        }

        private void OnImageSelected(string imageBase64)
        {
            selectedImage = imageBase64;
            // Aquí puedes manejar la lógica de lo que quieras hacer con la imagen
            Console.WriteLine("Imagen seleccionada: " + selectedImage);
        }

        private async Task SaveAsFile()
        {


            await JS.InvokeVoidAsync("saveFile", "miArchivo.txt", imageUrl);


        }
    }
}