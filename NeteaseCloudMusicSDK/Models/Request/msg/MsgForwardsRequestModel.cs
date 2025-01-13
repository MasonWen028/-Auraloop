using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve forwarded content in messages.
/// </summary>
public class MsgForwardsRequestModel
{
    /// <summary>
    /// Gets or sets the offset for pagination. Default is 0.
    /// </summary>
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;

    /// <summary>
    /// Gets or sets the maximum number of results to retrieve. Default is 30.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 30;

    const bool total = true;
}
