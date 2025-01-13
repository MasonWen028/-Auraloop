
using Newtonsoft.Json;

public class CloudImportRequestModel
{
    /// <summary>
    /// The name of the song.
    /// </summary>
    public string Song { get; set; }

    /// <summary>
    /// The file type (e.g., mp3, flac, wav).
    /// </summary>
    public string FileType { get; set; }

    /// <summary>
    /// The size of the file in bytes.
    /// </summary>
    public long FileSize { get; set; }

    /// <summary>
    /// The bitrate of the audio file.
    /// </summary>
    public int Bitrate { get; set; }

    /// <summary>
    /// The MD5 hash of the file.
    /// </summary>
    public string Md5 { get; set; }

    /// <summary>
    /// Optional: The ID of the song (if applicable).
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    /// Optional: The artist of the song.
    /// </summary>
    public string Artist { get; set; }

    /// <summary>
    /// Optional: The album of the song.
    /// </summary>
    public string Album { get; set; }
}
