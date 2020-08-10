using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BlazorWasmId4Authentication.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddHttpClient("BlazorWasmId4Authentication.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorWasmId4Authentication.ServerAPI"));

            builder.Services.AddAuthorizationCore(config =>
            {
                config.AddPolicy("Admin", policy =>
                 {
                     policy.RequireRole("blazortestadmin");
                 });
            });
            builder.Services.AddOidcAuthentication(options =>
            {
                options.UserOptions.RoleClaim = "role";
                builder.Configuration.Bind("identityserver", options.ProviderOptions);
            });

            await builder.Build().RunAsync();
        }
    }
}
