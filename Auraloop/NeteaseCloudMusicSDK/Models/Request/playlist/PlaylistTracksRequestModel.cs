
using Newtonsoft.Json;

public class PlaylistTracksRequestModel
{
    [JsonProperty("op")]
    public string Op { get; set; }
    [JsonProperty("pid")]
    public long Pid { get; set; }
    [JsonProperty("trackIds")]
    public string TrackIds { get; set; }
    [JsonProperty("imme")]
    public string Imme { get; set; }
}

public enum Optype
{
    add,
    del
}
