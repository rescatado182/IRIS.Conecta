using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Headers;
using TabBlazor;
using Microsoft.AspNetCore.Components.Web;
using IRIS.Frontend.Repositories;

namespace IRIS.UI.Wasm
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

            builder.Services.AddScoped<IRepository, Repository>();

            builder.Services.AddTabler();

            await builder.Build().RunAsync();
        }
    }
}