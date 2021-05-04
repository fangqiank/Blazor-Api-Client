using System.Text.Json.Serialization;

namespace BlazorApiClient.Dtos
{
    public class LaunchData
    {
        [JsonPropertyName("launches")]
        public LaunchDto[] Launches { get; set; }
    }
}
