using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to subscribe or unsubscribe to an MV.
/// </summary>
public class MvSubscribeRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the MV.
    /// </summary>
    [JsonProperty("mvid")]
    public long MvId { get; set; }

    /// <summary>
    /// Gets or sets the subscription operation.
    /// Use 1 for subscribe and 0 for unsubscribe.
    /// </summary>
    [JsonProperty("t")]
    public int Operation { get; set; }
}
