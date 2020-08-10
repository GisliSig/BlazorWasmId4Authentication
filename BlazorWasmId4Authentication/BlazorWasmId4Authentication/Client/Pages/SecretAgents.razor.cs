using BlazorWasmId4Authentication.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorWasmId4Authentication.Client.Pages
{
    [Authorize(Policy = "Admin")]
    public partial class SecretAgents
    {
        [Inject]
        private HttpClient Http { get; set; }

        private SecretAgent[] _agents;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                _agents = await Http.GetFromJsonAsync<SecretAgent[]>("api/SecretAgent");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }
    }
}
