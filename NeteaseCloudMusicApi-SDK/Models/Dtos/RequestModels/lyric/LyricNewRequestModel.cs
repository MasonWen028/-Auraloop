
using Newtonsoft.Json;

public class LyricNewRequestModel
{
    [JsonProperty("id")]
    public long Id { get; set; }
    [JsonProperty("cp")]
    public bool Cp { get; set; } = false;
    [JsonProperty("tv")]
    public int Tv { get; set; } = 0;
    [JsonProperty("lv")]
    public int Lv { get; set; } = 0;
    [JsonProperty("rv")]
    public int Rv { get; set; } = 0;
    [JsonProperty("kv")]
    public int Kv { get; set; } = 0;
    [JsonProperty("yv")]
    public int Yv { get; set; } = 0;
    [JsonProperty("ytv")]
    public int Ytv { get; set; } = 0;
    [JsonProperty("yrv")]
    public int Yrv { get; set; } = 0;
}
