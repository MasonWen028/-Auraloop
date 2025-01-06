
using Newtonsoft.Json;

public class VoicelistSearchRequestModel
{
    [JsonProperty("fee")]
    public string Fee { get; set; }
    [JsonProperty("limit")]
    public string Limit { get; set; }
    [JsonProperty("offset")]
    public string Offset { get; set; }
    [JsonProperty("podcastName")]
    public string PodcastName { get; set; }
}
