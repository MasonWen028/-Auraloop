using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve songs similar to a specified song.
/// </summary>
public class SimiSongRequestModel
{
    [JsonProperty("songid")]
    public long SongId { get; set; }

    [JsonProperty("limit")]
    public int Limit { get; set; } = 50;

    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;
}
