
using Newtonsoft.Json;

public class MvUrlRequestModel
{
    [JsonProperty("id")]
    public long Id { get; set; }
    [JsonProperty("r")]
    public int R { get; set; }
}
