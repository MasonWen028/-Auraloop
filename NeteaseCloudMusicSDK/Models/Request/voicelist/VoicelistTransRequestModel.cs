using Newtonsoft.Json;

public class VoicelistTransRequestModel
{
    [JsonProperty("radioId")]
    public long? RadioId { get; set; } = null;

    [JsonProperty("programId")]
    public long ProgramId { get; set; } = 0;

    [JsonProperty("position")]
    public int Position { get; set; } = 1;

    [JsonProperty("limit")]
    public int Limit { get; set; } = 200;

    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;
}
