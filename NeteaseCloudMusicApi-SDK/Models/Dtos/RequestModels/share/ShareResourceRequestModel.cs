
using Newtonsoft.Json;

public class ShareResourceRequestModel
{
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("msg")]
    public string Msg { get; set; }
    [JsonProperty("id")]
    public string Id { get; set; }
}
