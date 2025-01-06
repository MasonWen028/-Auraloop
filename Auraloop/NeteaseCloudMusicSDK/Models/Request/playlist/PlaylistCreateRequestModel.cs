
using Newtonsoft.Json;

public class PlaylistCreateRequestModel
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("privacy")]
    public PlaylistPrivacy Privacy { get; set; } = PlaylistPrivacy.NORMAL;
    [JsonProperty("type")]
    public PlaylistType Type { get; set; } = PlaylistType.NORMAL;
}

public enum PlaylistPrivacy
{
    NORMAL = 0,
    PRIVATE = 10
}

public enum PlaylistType
{
    NORMAL,
    VIDEO,
    SHARED
}
