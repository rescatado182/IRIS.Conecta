using System.ComponentModel.DataAnnotations;

namespace IRIS.Conecta.Domain.Enums
{
    public enum TicketRequirements
    {
        [Display(Name = "Transporte Aéreo")]
        AirTransport = 1,

        [Display(Name = "Transporte Terrestre")]
        LandTransportation = 2,

        [Display(Name = "Gastos de Viaje")]
        TravelExpenses = 3,

        [Display(Name = "Inscripción")]
        Inscription = 4
    }
}
