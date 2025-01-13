
using Newtonsoft.Json;

public class SongMusicDetailRequestModel
{
    [JsonProperty("songId")]
    public long SongId { get; set; }
}
