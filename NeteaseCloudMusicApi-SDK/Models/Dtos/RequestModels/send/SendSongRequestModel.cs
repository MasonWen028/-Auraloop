
using Newtonsoft.Json;

public class SendSongRequestModel
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("msg")]
    public string Msg { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("userIds")]
    public string UserIds { get; set; }
}
