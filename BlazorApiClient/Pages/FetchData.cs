using BlazorApiClient.Dtos;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BlazorApiClient.Pages
{
    public partial class FetchData
    {
        [Inject]
        private HttpClient Http { get; set; }

        private LaunchDto[] _launches;

        protected override async Task OnInitializedAsync()
        {
            _launches = await Http.GetFromJsonAsync<LaunchDto[]>("/rest/launches");
        }
    }
}
