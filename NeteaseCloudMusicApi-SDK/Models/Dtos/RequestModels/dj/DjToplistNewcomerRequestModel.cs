
using Newtonsoft.Json;

public class DjToplistNewcomerRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
}