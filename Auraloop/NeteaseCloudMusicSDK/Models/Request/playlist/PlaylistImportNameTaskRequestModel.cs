using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to create a task for importing playlist names.
/// </summary>
public class PlaylistImportNameTaskRequestModel
{
    /// <summary>
    /// Gets or sets a flag indicating whether to import the "Liked Songs" playlist.
    /// </summary>
    [JsonProperty("importStarPlaylist")]
    public bool ImportStarPlaylist { get; set; } = false;

    /// <summary>
    /// Gets or sets the local metadata for the import.
    /// This can be a JSON string containing song metadata (optional).
    /// </summary>
    [JsonProperty("local")]
    public string Local { get; set; }

    /// <summary>
    /// Gets or sets the text for importing playlist names.
    /// Used for text-based imports.
    /// </summary>
    [JsonProperty("text")]
    public string Text { get; set; }

    /// <summary>
    /// Gets or sets the link for importing playlists.
    /// Used for link-based imports.
    /// </summary>
    [JsonProperty("link")]
    public string Link { get; set; }

    /// <summary>
    /// Name of the playlist to be created or imported.
    /// </summary>
    public string PlaylistName { get; set; }
}

public class ImportPlaylistParameter
{
    /// <summary>
    /// Indicates whether to import the "Liked Songs" playlist.
    /// </summary>
    public bool ImportStarPlaylist { get; set; }

    /// <summary>
    /// Contains JSON-formatted metadata for multiple songs.
    /// </summary>
    public string MultiSongs { get; set; }

    /// <summary>
    /// Name of the playlist to be created or imported.
    /// </summary>
    public string PlaylistName { get; set; }

    /// <summary>
    /// Optional business code for the playlist creation process.
    /// </summary>
    public string CreateBusinessCode { get; set; }

    /// <summary>
    /// Optional external parameters for additional configurations.
    /// </summary>
    public string ExtParam { get; set; }

    /// <summary>
    /// Task identifier used for logging purposes.
    /// </summary>
    public string TaskIdForLog { get; set; }

    /// <summary>
    /// JSON-formatted string representing songs to be imported.
    /// </summary>
    public string Songs { get; set; }
}

