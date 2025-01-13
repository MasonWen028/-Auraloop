using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve the user's comment history.
/// </summary>
public class UserCommentHistoryRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; } = 10;

    [JsonProperty("user_id")]
    public long UserId { get; set; }

    [JsonProperty("time")]
    public long Time { get; set; } = 0;

    [JsonProperty("compose_reminder")]
    public bool ComposeReminder { get; set; } = true;

    [JsonProperty("compose_hot_comment")]
    public bool ComposeHotComment { get; set; } = true;
}
