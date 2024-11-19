using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text;
using IRIS.UI.Models.List;
using IRIS.UI.Services;
using System.Net.Http;

namespace IRIS.UI.Pages.BL.Actions
{
    public partial class SimilarAnswerTicket
    {
        // Inyecciones de servicios
        [Inject] IHttpClientFactory HttpClientFactory { get; set; }
        [Inject] private HttpClient HttpClient { get; set; }

        [Parameter] public string tipo_movilidad { get; set; }


        [Parameter]
        public string Query { get; set; }

        private string tipo_solicitud = "Movilidad";

        // Propiedades privadas

        private List<Resultado> resultados = new();
        private string responseMessage;
        private ServiceResponse serviceResponse;

        private string GenerateLink(string ticketId) => $"/ticketDetails/{ticketId}";

        // Inicialización del request
        private RootRequest rootRequest = new RootRequest
        {
            Body = new BodyRequest
            {
                Query = "",
                Filtros = new Filters(),
                Top_k = 3
            }
        };

        // Método para enviar datos al servicio

        protected override async Task OnInitializedAsync() {
           await  SendData();
        }
        private async Task SendData()
        {
            try
            {
                // Obtén el HttpClient configurado para la API externa
                var client = HttpClientFactory.CreateClient("ExternalApi");

                string endpoint = "https://ww4onj5obf.execute-api.us-east-1.amazonaws.com/prod/search";

                // Actualiza los filtros dinámicamente
                rootRequest.Body.Query = Query;
                rootRequest.Body.Filtros.tipo_solicitud = tipo_solicitud;
                rootRequest.Body.Filtros.tipo_movilidad = tipo_movilidad;

                Console.WriteLine(tipo_solicitud, tipo_movilidad);

                // Enviar el JSON como POST
                var response = await client.PostAsJsonAsync(endpoint, rootRequest);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadFromJsonAsync<ServiceResponse>();

                    if (jsonResponse?.Body?.Resultados != null)
                    {
                        resultados = jsonResponse.Body.Resultados.Select(r => new Resultado
                        {
                            Id = r.Id,
                            Solicitud = r.Solicitud,
                            Respuesta = r.Respuesta,
                            tipo_solicitud = r.tipo_solicitud,
                            tipo_movilidad = r.tipo_movilidad,
                            Facultad = r.Facultad,
                            Programa = r.Programa

                        }).ToList();
                    }

                }
                else
                {
                    serviceResponse = null;
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
        }

        // Método para formatear los resultados
        private string FormatResultados()
        {
            if (serviceResponse?.Body?.Resultados == null || !serviceResponse.Body.Resultados.Any())
                return "No hay resultados.";

            // Formatea cada resultado
            var resultadosFormateados = serviceResponse.Body.Resultados.Select(r =>
                $"ID: {r.Id}\nSolicitud: {r.Solicitud}\nRespuesta: {r.Respuesta}\nScore: {r.Score:F2}");

            return string.Join("\n\n", resultadosFormateados);
        }
    }
}
