namespace IRIS.UI.Models.List
{
    public class TimelineItemVM
    {
        public string Time { get; set; }      // Fecha o tiempo del evento
        public string Title { get; set; }     // Título del evento
        public string Description { get; set; } // Descripción o detalle del evento
        public string IconColor { get; set; } // Color del ícono
        public string IconText { get; set; }  // Texto del ícono o alternativa
    }
}
