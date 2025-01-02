
using Newtonsoft.Json;

public class UserPlaylistRequestModel
{
    [JsonProperty("uid")]
    public string Uid { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("includeVideo")]
    public bool IncludeVideo { get; set; }
}
