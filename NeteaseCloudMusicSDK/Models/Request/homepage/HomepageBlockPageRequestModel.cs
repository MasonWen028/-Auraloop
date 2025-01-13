using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve homepage content blocks.
/// </summary>
public class HomepageBlockPageRequestModel
{
    /// <summary>
    /// Gets or sets a value indicating whether to refresh the homepage content. Default is false.
    /// </summary>
    [JsonProperty("refresh")]
    public bool Refresh { get; set; } = false;

    /// <summary>
    /// Gets or sets the cursor for pagination or retrieving additional content.
    /// </summary>
    [JsonProperty("cursor")]
    public string Cursor { get; set; }
}
