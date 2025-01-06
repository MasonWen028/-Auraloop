
using Newtonsoft.Json;

public class MlogUrlRequestModel
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("resolution")]
    public int Resolution { get; set; }
    [JsonProperty("type")]
    public int Type { get; set; }
}
