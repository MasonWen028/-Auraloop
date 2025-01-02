
using Newtonsoft.Json;

public class VoicelistTransRequestModel
{
    [JsonProperty("limit")]
    public string Limit { get; set; }
    [JsonProperty("offset")]
    public string Offset { get; set; }
    [JsonProperty("radioId")]
    public string RadioId { get; set; }
    [JsonProperty("programId")]
    public string ProgramId { get; set; }
    [JsonProperty("position")]
    public string Position { get; set; }
}
