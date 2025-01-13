using Newtonsoft.Json;

public class RadioTrashSongRequestModel
{
    [JsonProperty("songId")]
    public long Id { get; set; }

    [JsonProperty("time")]
    public long Time { get; set; } = 25;

    const string alg = "RT";
}
