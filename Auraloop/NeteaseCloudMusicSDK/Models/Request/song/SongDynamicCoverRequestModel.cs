
using Newtonsoft.Json;

public class SongDynamicCoverRequestModel
{
    [JsonProperty("songId")]
    public long SongId { get; set; }
}
