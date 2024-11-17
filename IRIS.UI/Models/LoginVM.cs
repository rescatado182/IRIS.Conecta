using System.ComponentModel.DataAnnotations;

namespace IRIS.UI.Models
{
    public class LoginVM
    {
            public string id { get; set; }

            [Required(ErrorMessage = "Ingresa tu correo electronico")]
            public string email { get; set; }

            [Required(ErrorMessage = "Ingresa tu contraseña")]
            public string? password { get; set; }

             public string token { get; set; }

        public string username { get; set; }

    }   
        
            

    
}
