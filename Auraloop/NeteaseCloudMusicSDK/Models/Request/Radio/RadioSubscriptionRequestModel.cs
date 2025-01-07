using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to subscribe or unsubscribe to a radio station.
/// </summary>
public class RadioSubscriptionRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the radio station.
    /// </summary>
    [JsonProperty("rid")]
    public long RadioId { get; set; }

    /// <summary>
    /// Gets or sets the type of subscription operation.
    /// Possible values: "sub" for subscribing or "unsub" for unsubscribing.
    /// </summary>
    [JsonProperty("subOpType")]
    public string SubscriptionType { get; set; } = "sub";
}
