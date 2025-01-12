
using Newtonsoft.Json;



public class SearchMatchRequestModel
{
    [JsonProperty("songs")]
    public SearchMatchSongs[] Songs { get; set; }
}


public class SearchMatchSongs
{
    /// <summary>
    /// The title of the file, retrieved from the file's metadata, not the filename.
    /// </summary>
    [JsonProperty("title")]
    public string Title { get; set; }

    /// <summary>
    /// The album information of the file.
    /// </summary>
    [JsonProperty("album")]
    public string Album { get; set; }

    /// <summary>
    /// The artist information of the file.
    /// </summary>
    [JsonProperty("artist")]
    public string Artist { get; set; }

    /// <summary>
    /// The duration of the file in seconds.
    /// </summary>
    [JsonProperty("duration")]
    public int Duration { get; set; }

    /// <summary>
    /// The MD5 checksum of the file.
    /// </summary>
    [JsonProperty("md5")]
    public string Md5 { get; set; }
}
