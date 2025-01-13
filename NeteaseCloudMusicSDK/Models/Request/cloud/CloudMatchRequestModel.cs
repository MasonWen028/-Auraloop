
using Newtonsoft.Json;

public class CloudMatchRequestModel
{
    [JsonProperty("userId")]
    public long UserId { get; set; }
    [JsonProperty("songId")]
    public long SongId { get; set; }
    [JsonProperty("adjustSongId")]
    public long AdjustSongId { get; set; }
}
