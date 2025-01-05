
using Newtonsoft.Json;

public class FmTrashRequestModel
{
    [JsonProperty("songId")]
    public long SongId { get; set; }
    [JsonProperty("alg")]
    public string Alg { get; set; }
    [JsonProperty("time")]
    public long Time { get; set; }
}
