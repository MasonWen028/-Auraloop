
using Newtonsoft.Json;

public class ScrobbleRequestModel
{
    [JsonProperty("logs")]
    public string Logs { get; set; }
    [JsonProperty("json")]
    public string Json { get; set; }
    [JsonProperty("end")]
    public string End { get; set; }
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("sourceId")]
    public string SourceId { get; set; }
    [JsonProperty("time")]
    public long Time { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("wifi")]
    public int Wifi { get; set; }
    [JsonProperty("source")]
    public string Source { get; set; }
    [JsonProperty("mainsite")]
    public int Mainsite { get; set; }
    [JsonProperty("content")]
    public string Content { get; set; }
}
