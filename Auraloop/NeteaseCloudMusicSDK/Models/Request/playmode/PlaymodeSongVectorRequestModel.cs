using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve song vectors for play mode personalization.
/// </summary>
public class PlaymodeSongVectorRequestModel
{
    /// <summary>
    /// Gets or sets the list of song IDs for which to retrieve vector data.
    /// </summary>
    [JsonProperty("ids")]
    public long[] SongIds { get; set; }
}
