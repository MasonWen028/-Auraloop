
using Newtonsoft.Json;

public class PlaymodeIntelligenceListRequestModel
{
    [JsonProperty("songId")]
    public long SongId { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("playlistId")]
    public long PlaylistId { get; set; }
    [JsonProperty("startMusicId")]
    public long StartMusicId { get; set; }
    [JsonProperty("count")]
    public int Count { get; set; }
}
