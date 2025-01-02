
using Newtonsoft.Json;

public class CloudMatchRequestModel
{
    [JsonProperty("userId")]
    public string UserId { get; set; }
    [JsonProperty("songId")]
    public string SongId { get; set; }
    [JsonProperty("adjustSongId")]
    public string AdjustSongId { get; set; }
}
