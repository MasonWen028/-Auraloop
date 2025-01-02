
using Newtonsoft.Json;

public class PlaylistDescUpdateRequestModel
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("desc")]
    public string Desc { get; set; }
}
