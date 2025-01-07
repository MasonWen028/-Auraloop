using Newtonsoft.Json;

public class VoiceListRequestModel
{
    [JsonProperty("voiceListId")]
    public long VoiceListId { get; set; }

    [JsonProperty("limit")]
    public int Limit { get; set; } = 200;

    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;
}
