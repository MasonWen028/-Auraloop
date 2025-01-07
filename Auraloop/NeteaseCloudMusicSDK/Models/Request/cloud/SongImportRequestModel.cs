using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to import songs to the cloud.
/// </summary>
public class SongImportRequestModel
{
    /// <summary>
    /// Gets or sets the list of songs to be imported.
    /// </summary>
    [JsonProperty("songs")]
    public string[] Songs { get; set; }
}
