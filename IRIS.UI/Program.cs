using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Headers;
using TabBlazor;
using Microsoft.AspNetCore.Components.Web;
using IRIS.Frontend.Repositories;
using TabBlazor.Services;
using IRIS.UI.Services.BL;
using IRIS.UI.Services;
using ColorCode.Compilation.Languages;
using IRIS.UI.Pages.BL.Tickets.RequestTickets.Movility;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using IRIS.UI.AuthenticationProviders;
using System.Text.Json; // Add this using directive
using System.Text.Json.Serialization; // Add this using directive

namespace IRIS.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            // Configurar HttpClient y los servicios JSON
            builder.Services.AddHttpClient("GitHub", client => client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("TabBlazor", "1")))
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()) // Establece el handler base
                .AddHttpMessageHandler(() => new JsonOptionsHandler(new JsonSerializerOptions
                {
                    Converters = { new DateOnlyJsonConverter() } // Agregar el convertidor personalizado
                }));

            //builder.Services.AddHttpClient("Local", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            builder.Services.AddHttpClient("GitHub", client => client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("TabBlazor", "1")));


            // Agregar servicios de autorización
            builder.Services.AddAuthorizationCore();

            builder.Services.AddScoped<AuthenticationProviderJWT>();

            builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationProviderJWT>();
            builder.Services.AddScoped<ILoginService, AuthenticationProviderJWT>();
            builder.Services.AddScoped<INotificationService, NotificationService>();

            builder.Services.AddScoped<IRepository, Repository>();
            builder.Services.AddScoped<IModalService, ModalService>();
            builder.Services.AddSingleton<TicketMovilityRequest>();


            builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7225/") });


            builder.Services.AddScoped<SearchService>();


            builder.Services.AddDocs();
            builder.Services.AddTabler();

            await builder.Build().RunAsync();

            var app = builder.Build();
        }
    }

    public class JsonOptionsHandler : DelegatingHandler
    {
        private readonly JsonSerializerOptions _options;

        public JsonOptionsHandler(JsonSerializerOptions options)
        {
            _options = options;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Content = new StringContent(JsonSerializer.Serialize(request.Content, _options));
            return await base.SendAsync(request, cancellationToken);
        }
    }
}