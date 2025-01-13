
using Newtonsoft.Json;

public class PlaylistOrderUpdateRequestModel
{
    /// <summary>
    /// Gets or sets the IDs of playlists in the desired order.
    /// </summary>
    [JsonProperty("ids")]
    public long[] PlaylistIds { get; set; }
}
