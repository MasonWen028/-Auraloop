using Newtonsoft.Json;

public class RadioTrashSongRequestModel
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("time")]
    public long Time { get; set; } = 25;
}
