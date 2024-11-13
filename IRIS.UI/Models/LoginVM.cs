using System.ComponentModel.DataAnnotations;

namespace IRIS.UI.Models
{
    public class LoginVM
    {
            public string id { get; set; }

            [Required(ErrorMessage = "Correo electronico es requerido")]
            public string email { get; set; }

            [Required(ErrorMessage = "Contraseña es requerido")]
            public string? password { get; set; }

             public string token { get; set; }

        public string username { get; set; }

    }   
        
            

    
}
