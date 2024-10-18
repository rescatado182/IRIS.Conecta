using System.ComponentModel.DataAnnotations;

namespace IRIS.UI.Models
{
    public enum TicketsStatus
    {
        [Display(Name = "Abierto")]
        Open = 1,
        [Display(Name = "Cerrado")]
        Closed = 2,
        [Display(Name = "En Proceso")]
        InProcess = 3,
        [Display(Name = "Resuelto")]
        Resolved = 4,
        [Display(Name = "Respuesto")]
        Responded = 5
    }
}
