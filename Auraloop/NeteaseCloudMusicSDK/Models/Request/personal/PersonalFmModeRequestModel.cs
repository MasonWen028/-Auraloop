
using Newtonsoft.Json;

public class PersonalFmModeRequestModel
{
    [JsonProperty("mode")]
    public string Mode { get; set; }
    [JsonProperty("subMode")]
    public string SubMode { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
}
