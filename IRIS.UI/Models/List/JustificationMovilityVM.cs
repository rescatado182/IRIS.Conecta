namespace IRIS.UI.Models.List
{
    public class JustificationMovilityVM
    {
        // Convenio (S/A)
        public string AgreementName { get; set; }

        // Objetivo de la solicitud
        public string Description { get; set; }
        public bool IsAgreement { get; set; }
        public string Results { get; set; }
        public DateOnly DeliveryDate { get; set; }
    }
}
