
using Newtonsoft.Json;

public class PlaymodeIntelligenceListRequestModel
{
    [JsonProperty("songId")]
    public string SongId { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("playlistId")]
    public string PlaylistId { get; set; }
    [JsonProperty("startMusicId")]
    public string StartMusicId { get; set; }
    [JsonProperty("count")]
    public int Count { get; set; }
}
