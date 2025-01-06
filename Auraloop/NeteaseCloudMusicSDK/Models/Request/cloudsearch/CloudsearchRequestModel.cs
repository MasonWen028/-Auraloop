
using Newtonsoft.Json;

public class CloudsearchRequestModel
{
    [JsonProperty("s")]
    public string S { get; set; }
    [JsonProperty("type")]
    public SearchTypes Type { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("total")]
    public bool Total { get; set; }
}
