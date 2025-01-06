using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve a list of music sheets.
/// </summary>
public class SheetListRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier for the music sheet query.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the A/B test variation for the request. Default is "b".
    /// </summary>
    [JsonProperty("abTest")]
    public string AbTest { get; set; } = "b";
}
