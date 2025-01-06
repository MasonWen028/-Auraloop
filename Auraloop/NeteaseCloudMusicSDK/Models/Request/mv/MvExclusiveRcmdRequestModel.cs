
using Newtonsoft.Json;

public class MvExclusiveRcmdRequestModel
{
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
}
