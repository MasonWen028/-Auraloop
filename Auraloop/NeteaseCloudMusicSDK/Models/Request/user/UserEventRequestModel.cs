using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve the user's event feed.
/// </summary>
public class UserEventRequestModel
{
    [JsonProperty("uid")]
    public long UserId { get; set; }

    [JsonProperty("limit")]
    public int Limit { get; set; } = 30;

    [JsonProperty("lasttime")]
    public long LastTime { get; set; } = -1;
}
