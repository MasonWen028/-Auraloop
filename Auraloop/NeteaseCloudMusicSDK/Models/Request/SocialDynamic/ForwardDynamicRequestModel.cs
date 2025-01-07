using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to forward a dynamic.
/// </summary>
public class ForwardDynamicRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the dynamic to forward.
    /// </summary>
    [JsonProperty("id")]
    public long DynamicId { get; set; }

    /// <summary>
    /// Gets or sets the content of the forward message.
    /// </summary>
    [JsonProperty("forwards")]
    public string Forwards { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user creating the forward.
    /// </summary>
    [JsonProperty("eventUserId")]
    public long EventUserId { get; set; }
}
