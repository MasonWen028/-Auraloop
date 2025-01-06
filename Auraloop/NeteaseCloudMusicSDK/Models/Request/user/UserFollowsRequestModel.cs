
using Newtonsoft.Json;

public class UserFollowsRequestModel
{
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("order")]
    public bool Order { get; set; }
}
