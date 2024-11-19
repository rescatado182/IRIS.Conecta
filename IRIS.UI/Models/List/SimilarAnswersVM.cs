using DocumentFormat.OpenXml.Spreadsheet;

namespace IRIS.UI.Models.List
{
    public class SimilarAnswersVM
    {
        public string id { get; set; }

        public string Request { get; set; }

        public string Answer { get; set; }

        public string score { get; set; }
    }

    public class RootRequest
    {
        public BodyRequest Body { get; set; }
    }

    public class BodyRequest
    {
        public string Query { get; set; }
        public Filters Filtros { get; set; }
        public int Top_k { get; set; }
    }

    public class Filters
    {
        public string tipo_solicitud { get; set; }

        public string tipo_movilidad { get; set; }
    }

    public class ServiceResponse
    {
        public int StatusCode { get; set; }
        public ResponseBody Body { get; set; }

    }

    public class ResponseBody
    {
        public List<Resultado> Resultados { get; set; }
    }

    public class Resultado
    {
        public string Id { get; set; }
        public string Solicitud { get; set; }
        public string Respuesta { get; set; }
        public string tipo_solicitud { get; set; }
        public string tipo_movilidad { get; set; }
        public string Programa { get; set; }
        public string Facultad { get; set; }
        public float Score { get; set; }
    }
}
