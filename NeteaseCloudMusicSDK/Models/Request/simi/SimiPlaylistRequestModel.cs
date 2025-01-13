using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve playlists similar to a song.
/// </summary>
public class SimiPlaylistRequestModel
{
    [JsonProperty("songid")]
    public long SongId { get; set; }

    [JsonProperty("limit")]
    public int Limit { get; set; } = 50;

    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;
}
