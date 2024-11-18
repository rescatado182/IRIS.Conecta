using IRIS.UI.Models.List;
using System.Net.Http.Json;

namespace IRIS.UI.Services
{
    public class SearchService
    {
        private readonly HttpClient _httpClient;

        public SearchService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ExternalApi");
        }

        public async Task<ServiceResponse> SearchAsync(RootRequest rootRequest)
        {
            string endpoint = "prod/search";
            var response = await _httpClient.PostAsJsonAsync(endpoint, rootRequest);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ServiceResponse>();
            }

            return null;
        }
    }

}
