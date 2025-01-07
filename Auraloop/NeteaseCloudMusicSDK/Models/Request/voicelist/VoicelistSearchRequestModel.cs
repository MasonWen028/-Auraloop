using Newtonsoft.Json;

public class VoiceListSearchRequestModel
{
    [JsonProperty("name")]
    public string Name { get; set; } = null;

    [JsonProperty("displayStatus")]
    public int? DisplayStatus { get; set; } = null;

    [JsonProperty("type")]
    public int? Type { get; set; } = null;

    [JsonProperty("voiceFeeType")]
    public int? VoiceFeeType { get; set; } = null;

    [JsonProperty("radioId")]
    public long? RadioId { get; set; } = null;

    [JsonProperty("limit")]
    public int Limit { get; set; } = 200;

    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;
}
