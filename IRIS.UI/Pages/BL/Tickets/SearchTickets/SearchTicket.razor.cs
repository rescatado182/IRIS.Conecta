using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using IRIS.Frontend.Repositories;
using IRIS.UI.AuthenticationProviders;
using IRIS.UI.Icons;
using IRIS.UI.Models.List;
using IRIS.UI.Pages.BL.Actions;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using TabBlazor;
using TabBlazor.Services;


namespace IRIS.UI.Pages.BL.Tickets.SearchTickets
{
    public partial class SearchTicket
    {
        [Inject] IHttpClientFactory HttpClientFactory { get; set; }
        [Inject] private HttpClient HttpClient { get; set; }

        [Inject] TablerService TablerService { get; set; }
        [Inject] private IRepository Repository { get; set; } = null!;

        [Inject] private IModalService ModalService { get; set; } = null!;

        [Inject] IOffcanvasService offcanvasService { get; set; }

        private string CurrentStatus;

        private bool IsActionPanelVisible { get; set; } = false;

        private void ToggleActionPanel()
        {
            IsActionPanelVisible = !IsActionPanelVisible;
        }
        private int? SelectedTicketId { get; set; }
        private bool IsTicketDetailsVisible { get; set; } = false;
        private string statusText { get; set; } = null!;

        public List<ManagersListVM> managers { get; set; }
        public GetTicketbyIdVM ticket { get; set; } = null!;

        public GetTicketbyIdVM selectedOrders { get; set; } = null!;


        public PersonalDataDetailVM personalDataTicket { get; set; } = null!;

        public AcademyDataDetailVM academicDataTicket { get; set; } = null!;

        [Parameter] public string tipo_movilidad { get; set; }


        [Parameter]
        public string Query { get; set; }

        private string tipo_solicitud = "Movilidad";

        // Propiedades privadas

        private List<Resultado> resultados = new();
        private string responseMessage;
        private ServiceResponse serviceResponse;

        private string GenerateLink(string ticketId) => $"/ticketDetails/{ticketId}";




        private RootRequest rootRequest = new RootRequest
        {
            Body = new BodyRequest
            {
                Query = "",
                Filtros = new Models.List.Filters(),
                Top_k = 3
            }
        };

        private async Task GetTicketByIdAsync()
        {

            var responseHttp = await Repository.GetAsync<GetTicketbyIdVM>($"/api/Tickets/{Query}");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();

            }

            ticket = responseHttp.Response;
            statusText = ticket.StatusDisplayName;

            await GetListPersonalDataTicketAsync();
            await GetListAcademicDataTicketAsync();


            await GetListManagersAsync();


            await GetListUserNameAsync();
                

        }

        private async Task<bool> GetListManagersAsync()
        {
            var responseHttp = await Repository.GetAsync<List<ManagersListVM>>("/api/Users/GetManagers");

            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                return false;
            }

            managers = responseHttp.Response;
            var manager = managers.FirstOrDefault(m => m.Id == ticket.ManagerUserId);
            if (manager != null)
            {
                ticket.ManagerUserName = manager.FullName;
            }

            return true;
        }

        private async Task<bool> GetListUserNameAsync()
        {
            var responseHttp = await Repository.GetAsync<GetUserByUserIdVM>($"/api/Users/GetUserByUserId/{ticket.UserId}");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                return false;
            }

            var user = responseHttp.Response;
            ticket.UserName = user.FullName;
            return true;
        }

        private async Task<bool> GetListPersonalDataTicketAsync()
        {
            var responseHttp = await Repository.GetAsync<PersonalDataDetailVM>($"/api/personaldata/{ticket.personalDataId}");
            if (responseHttp.Error || responseHttp.Response == null)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                return false;
            }

            personalDataTicket = responseHttp.Response;
            return true;
        }

        private async Task<bool> GetListAcademicDataTicketAsync()
        {
            var responseHttp = await Repository.GetAsync<AcademyDataDetailVM>($"/api/academicdata/{ticket.academicDataId}");


            if (responseHttp.Error || responseHttp.Response == null)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                return false;
            }

            academicDataTicket = responseHttp.Response;
            return true;
        }



        private async Task SendData()
        {
            try
            {
                var client = HttpClientFactory.CreateClient("ExternalApi");
                string endpoint = "https://ww4onj5obf.execute-api.us-east-1.amazonaws.com/prod/search";

                rootRequest.Body.Query = Query;
                rootRequest.Body.Filtros.tipo_solicitud = tipo_solicitud;
                rootRequest.Body.Filtros.tipo_movilidad = tipo_movilidad;

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
                    responseMessage = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
                }
            }
            catch (Exception ex)
            {
                responseMessage = $"Excepción: {ex.Message}";
            }
        }


    }
}