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

namespace IRIS.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            //builder.Services.AddHttpClient("Local", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            builder.Services.AddHttpClient("GitHub", client => client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("TabBlazor", "1")));

            builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7225/") });

            // Agregar servicios de autorización
            builder.Services.AddAuthorizationCore();

            builder.Services.AddScoped<AuthenticationProviderJWT>();
            //builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationProviderJWT>(x => x.GetRequiredService<AuthenticationProviderJWT>());
            //builder.Services.AddScoped<ILoginService, AuthenticationProviderJWT>(x => x.GetRequiredService<AuthenticationProviderJWT>());

            builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationProviderJWT>();
            builder.Services.AddScoped<ILoginService, AuthenticationProviderJWT>();

            builder.Services.AddScoped<IRepository, Repository>();
            builder.Services.AddScoped<IModalService, ModalService>();
            builder.Services.AddSingleton<TicketMovilityRequest>();

            builder.Services.AddDocs();
            builder.Services.AddTabler();




            await builder.Build().RunAsync();

            var app = builder.Build();

        }
    }
}