using Newtonsoft.Json;

public class VipGrowthPointDetailsRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; } = 20;

    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;
}
