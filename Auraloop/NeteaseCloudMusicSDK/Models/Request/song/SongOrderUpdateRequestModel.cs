using Newtonsoft.Json;

public class SongOrderUpdateRequestModel
{
    [JsonProperty("pid")]
    public long PlaylistId { get; set; }

    [JsonProperty("trackIds")]
    public long[] TrackIds { get; set; }
}
