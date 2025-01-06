
using Newtonsoft.Json;

public class PersonalizedRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("total")]
    public bool Total { get; set; }
    [JsonProperty("n")]
    public int N { get; set; }
}
