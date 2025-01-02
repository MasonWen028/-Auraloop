
using Newtonsoft.Json;

public class VoicelistListSearchRequestModel
{
    [JsonProperty("limit")]
    public string Limit { get; set; }
    [JsonProperty("offset")]
    public string Offset { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("displayStatus")]
    public string DisplayStatus { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("voiceFeeType")]
    public string VoiceFeeType { get; set; }
    [JsonProperty("radioId")]
    public string RadioId { get; set; }
}
