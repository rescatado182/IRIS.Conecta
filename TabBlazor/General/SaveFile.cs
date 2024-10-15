using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabBlazor.General
{
    public class SaveFile
    {

        
        public static void SaveFiles (string fileBase64, string filePath)
        {
            try
            {
                // Eliminar el prefijo "data:image/jpeg;base64," si está presente
                if (fileBase64.Contains(","))
                {
                    fileBase64 = fileBase64.Split(',')[1];
                }

                // Convertir la cadena Base64 en un byte[]
                byte[] imageBytes = Convert.FromBase64String(fileBase64);

                // Guardar el archivo en la ruta especificada
                File.WriteAllBytes(filePath, imageBytes);

                Console.WriteLine("Imagen guardada correctamente en: " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar la imagen: " + ex.Message);
            }
        }

    }
}
