using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve comments sent to the user in messages.
/// </summary>
public class MsgCommentsRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the user.
    /// </summary>
    [JsonProperty("uid")]
    public long UserId { get; set; }

    /// <summary>
    /// Gets or sets the timestamp to fetch comments before a specific time. Default is "-1".
    /// </summary>
    [JsonProperty("beforeTime")]
    public string BeforeTime { get; set; } = "-1";

    /// <summary>
    /// Gets or sets the maximum number of results to retrieve. Default is 30.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 30;
}
