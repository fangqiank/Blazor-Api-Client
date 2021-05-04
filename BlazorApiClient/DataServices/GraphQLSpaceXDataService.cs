using BlazorApiClient.Dtos;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorApiClient.DataServices
{
    public class GraphQLSpaceXDataService:ISpaceXDataService
    {
        private readonly HttpClient _http;

        public GraphQLSpaceXDataService(HttpClient http)
        {
            _http = http;
        }

        public async Task<LaunchDto[]> GetAllLaunches()
        {
            var queryObj = new
            {
                query = @"{launches{id,is_tentative,mission_name,launch_date_local}}",
                variables =  new {}
            };

            var launchQuery = new StringContent(JsonSerializer.Serialize(queryObj), Encoding.UTF8, "application/json");

            var response = await _http.PostAsync("graphql", launchQuery);

            if (response.IsSuccessStatusCode)
            {
                var result = await JsonSerializer.DeserializeAsync<GqlData>(
                    await response.Content.ReadAsStreamAsync());

                return result.Data.Launches;
            }

            return null;
        }
    }
}
