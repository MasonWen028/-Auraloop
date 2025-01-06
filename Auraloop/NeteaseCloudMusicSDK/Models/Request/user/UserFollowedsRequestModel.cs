
using Newtonsoft.Json;

public class UserFollowedsRequestModel
{
    [JsonProperty("userId")]
    public string UserId { get; set; }
    [JsonProperty("time")]
    public long Time { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("getcounts")]
    public int Getcounts { get; set; }
}
