
using Newtonsoft.Json;

public class UserFollowMixedRequestModel
{
    [JsonProperty("authority")]
    public string Authority { get; set; }
    [JsonProperty("page")]
    public string Page { get; set; }
    [JsonProperty("cursor")]
    public string Cursor { get; set; }
}
