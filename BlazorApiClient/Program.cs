using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorApiClient.DataServices;

namespace BlazorApiClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(builder.Configuration["api_base_url"])
            });

            //Rest
            builder.Services.AddHttpClient<ISpaceXDataService, SpaceXDataService>(options =>
            {
                options.BaseAddress = new Uri(builder.Configuration["api_base_url"]);
            });
            
            //graphql
            /*
            builder.Services.AddHttpClient<ISpaceXDataService, GraphQLSpaceXDataService>(options =>
            {
                options.BaseAddress = new Uri(builder.Configuration["api_base_url"]);
            });
            */

            await builder.Build().RunAsync();
        }
    }
}
