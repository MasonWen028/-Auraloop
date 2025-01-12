
using Newtonsoft.Json;


public class SearchInputModel
{
    [JsonProperty("type")]
    public SearchTypes Type { get; set; }

    [JsonProperty("s")]
    public string Keywords { get; set; }

    [JsonProperty("limit")]
    public int Limit { get; set; } = 30;
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;
}


public class SearchAudioRequestModel
{
    [JsonProperty("keyword")]
    public string Keyword { get; set; }
    [JsonProperty("scene")]
    const string Scene = "normal";
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
}

public class SearchNormalRequestModel
{
    public SearchTypes Type { get; set; }

    public string Keywords { get; set; }

    [JsonProperty("limit")]
    public int Limit { get; set; } = 30;
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;
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
