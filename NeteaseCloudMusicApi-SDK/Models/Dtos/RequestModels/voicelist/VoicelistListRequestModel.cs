
using Newtonsoft.Json;

public class VoicelistListRequestModel
{
    [JsonProperty("limit")]
    public string Limit { get; set; }
    [JsonProperty("offset")]
    public string Offset { get; set; }
    [JsonProperty("voiceListId")]
    public string VoiceListId { get; set; }
}
