using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to update a playlist's cover image.
/// </summary>
public class PlaylistCoverUpdateRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the playlist.
    /// </summary>
    [JsonProperty("id")]
    public long PlaylistId { get; set; }

    /// <summary>
    /// Gets or sets the image file for the playlist cover.
    /// </summary>
    public byte[] ImgFile { get; set; }

    /// <summary>
    /// Gets or sets the name of the image file, including the extension (e.g., "cover.jpg").
    /// </summary>
    public string ImgFileName { get; set; }
}
