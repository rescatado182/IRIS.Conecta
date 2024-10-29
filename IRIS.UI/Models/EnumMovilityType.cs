using System.ComponentModel.DataAnnotations;

namespace IRIS.UI.Models
{
    public enum EnumMovilityType
    {

        [Display(Name = "Práctica Internacional")]
        InternationalPractice = 1,

        [Display(Name = "Doble Titulación")]
        DoubleDegree = 2,

        [Display(Name = "Intercambio Nacional e Internacional")]
        NationalAndInternationalExchange = 3,

        [Display(Name = "Pasantia de Investigación")]
        ResearchInternship = 4,

        [Display(Name = "Ponencia")]
        Presentation = 5,

        [Display(Name = "Representación Institucional")]
        InstitutionalRepresentation = 6

    }
}
