
using Newtonsoft.Json;

public class VipGrowthpointDetailsRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
}
