
using Newtonsoft.Json;

public class UserFollowsRequestModel
{
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;
    [JsonProperty("limit")]
    public int Limit { get; set; } = 30;
    [JsonProperty("order")]
    public bool Order { get; set; } = true;

    [JsonIgnore]
    public long UserId { get; set; }
}
