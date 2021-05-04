using System.Text.Json.Serialization;

namespace BlazorApiClient.Dtos
{
    public class GqlData
    {
        [JsonPropertyName("data")]
        public LaunchData Data { get; set; }
    }
}
