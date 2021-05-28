using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Fluxor;
using Fluxor.Blazor.Web.ReduxDevTools;

namespace JokesApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            builder.Services.AddScoped(sp => httpClient);

            // Fluxor
            var currentAssembly = typeof(Program).Assembly;
            builder.Services.AddFluxor(options => options
                .ScanAssemblies(currentAssembly)
                .UseReduxDevTools());

            await builder.Build().RunAsync();
        }
    }
}
