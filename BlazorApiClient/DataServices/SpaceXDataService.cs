using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorApiClient.Dtos;

namespace BlazorApiClient.DataServices
{
    public class SpaceXDataService:ISpaceXDataService
    {
        private readonly HttpClient _http;

        public SpaceXDataService(HttpClient http)
        {
            _http = http;
        }

        public async Task<LaunchDto[]> GetAllLaunches()
        {
            return await _http.GetFromJsonAsync<LaunchDto[]>("/rest/launches");
        }
    }
}
