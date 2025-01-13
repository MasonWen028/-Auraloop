using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to preview a specific music sheet.
/// </summary>
public class SheetPreviewRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier for the music sheet to preview.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }
}
