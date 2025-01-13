/// <summary>
/// Represents the request model for importing songs into the cloud.
/// </summary>
public class SongImportRequestModel
{
    /// <summary>
    /// The unique identifier for the song. Defaults to -2 if not provided.
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    /// The MD5 hash of the audio file.
    /// </summary>
    public string Md5 { get; set; }

    /// <summary>
    /// The bitrate of the audio file in kbps.
    /// </summary>
    public int Bitrate { get; set; }

    /// <summary>
    /// The size of the audio file in bytes.
    /// </summary>
    public long FileSize { get; set; }

    /// <summary>
    /// The name of the song.
    /// </summary>
    public string Song { get; set; }

    /// <summary>
    /// The name of the artist. Defaults to "未知" (Unknown) if not provided.
    /// </summary>
    public string Artist { get; set; }

    /// <summary>
    /// The name of the album. Defaults to "未知" (Unknown) if not provided.
    /// </summary>
    public string Album { get; set; }

    /// <summary>
    /// The file type of the audio file (e.g., "mp3").
    /// </summary>
    public string FileType { get; set; }
}
