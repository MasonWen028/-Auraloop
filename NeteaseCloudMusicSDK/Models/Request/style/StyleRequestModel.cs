using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required for fetching style-related data such as albums, artists, playlists, or songs.
/// </summary>
public class StyleRequestModel
{
    /// <summary>
    /// Gets or sets the cursor for pagination.
    /// </summary>
    [JsonProperty("cursor")]
    public int Cursor { get; set; } = 0;

    /// <summary>
    /// Gets or sets the number of items to retrieve.
    /// </summary>
    [JsonProperty("size")]
    public int Size { get; set; } = 20;

    /// <summary>
    /// Gets or sets the unique identifier for the style tag.
    /// </summary>
    [JsonProperty("tagId")]
    public long TagId { get; set; }

    /// <summary>
    /// Gets or sets the sort order. Default is 0.
    /// </summary>
    [JsonProperty("sort")]
    public int Sort { get; set; } = 0;
}
