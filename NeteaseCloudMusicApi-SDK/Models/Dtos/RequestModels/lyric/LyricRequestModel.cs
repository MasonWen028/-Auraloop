
using Newtonsoft.Json;

public class LyricRequestModel
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("tv")]
    public int Tv { get; set; }
    [JsonProperty("lv")]
    public int Lv { get; set; }
    [JsonProperty("rv")]
    public int Rv { get; set; }
    [JsonProperty("kv")]
    public int Kv { get; set; }
    [JsonProperty("_nmclfl")]
    public int Nmclfl { get; set; }
}
