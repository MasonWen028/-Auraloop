
using Newtonsoft.Json;

public class LyricNewRequestModel
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("cp")]
    public bool Cp { get; set; }
    [JsonProperty("tv")]
    public int Tv { get; set; }
    [JsonProperty("lv")]
    public int Lv { get; set; }
    [JsonProperty("rv")]
    public int Rv { get; set; }
    [JsonProperty("kv")]
    public int Kv { get; set; }
    [JsonProperty("yv")]
    public int Yv { get; set; }
    [JsonProperty("ytv")]
    public int Ytv { get; set; }
    [JsonProperty("yrv")]
    public int Yrv { get; set; }
}
