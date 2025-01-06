
using Newtonsoft.Json;

public class EventForwardRequestModel
{
    [JsonProperty("forwards")]
    public string Forwards { get; set; }
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("eventUserId")]
    public string EventUserId { get; set; }
}
