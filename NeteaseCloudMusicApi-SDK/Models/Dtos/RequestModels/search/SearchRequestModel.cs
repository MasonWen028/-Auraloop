
using Newtonsoft.Json;

public class SearchRequestModel
{
    [JsonProperty("keyword")]
    public string Keyword { get; set; }
    [JsonProperty("scene")]
    public string Scene { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
}

public enum SearchTypes
{
    Single = 1,
    Album = 10,
    Artist = 100,
    Playlist = 1000,
    User = 1002,
    Mv = 1004,
    Lyrics = 1006,
    Radio = 1009,
    Video = 1014,
    All = 1018,
    Audio = 2000,
}
