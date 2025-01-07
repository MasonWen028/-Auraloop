using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to upload a song to the cloud.
/// </summary>
public class SongUploadRequestModel
{
    /// <summary>
    /// Gets or sets the name of the song.
    /// </summary>
    [JsonProperty("song")]
    public string SongName { get; set; }

    /// <summary>
    /// Gets or sets the artist name. Default is "Unknown".
    /// </summary>
    [JsonProperty("artist")]
    public string Artist { get; set; } = "Unknown";

    /// <summary>
    /// Gets or sets the album name. Default is "Unknown".
    /// </summary>
    [JsonProperty("album")]
    public string Album { get; set; } = "Unknown";

    /// <summary>
    /// Gets or sets the file type of the song.
    /// </summary>
    [JsonProperty("fileType")]
    public string FileType { get; set; }

    /// <summary>
    /// Gets or sets the MD5 hash of the song file.
    /// </summary>
    [JsonProperty("md5")]
    public string Md5 { get; set; }

    /// <summary>
    /// Gets or sets the bitrate of the song file.
    /// </summary>
    [JsonProperty("bitrate")]
    public int Bitrate { get; set; }

    /// <summary>
    /// Gets or sets the file size of the song.
    /// </summary>
    [JsonProperty("fileSize")]
    public long FileSize { get; set; }
}
