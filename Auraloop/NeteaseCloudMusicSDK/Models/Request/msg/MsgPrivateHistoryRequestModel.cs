using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve the private message history for a specific conversation.
/// </summary>
public class MsgPrivateHistoryRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the user.
    /// </summary>
    [JsonProperty("userId")]
    public long UserId { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of results to retrieve. Default is 30.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 30;

    /// <summary>
    /// Gets or sets the timestamp to fetch messages before a specific time. Default is 0.
    /// </summary>
    [JsonProperty("time")]
    public long BeforeTime { get; set; } = 0;

    const bool total = true;
}
