
using Newtonsoft.Json;

public class SongDownloadUrlRequestModel
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("br")]
    public string Br { get; set; }
}
