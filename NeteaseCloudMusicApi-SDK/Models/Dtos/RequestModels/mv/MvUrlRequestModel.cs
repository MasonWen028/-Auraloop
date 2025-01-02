
using Newtonsoft.Json;

public class MvUrlRequestModel
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("r")]
    public int R { get; set; }
}
