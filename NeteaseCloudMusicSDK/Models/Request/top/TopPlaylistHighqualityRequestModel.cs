
using Newtonsoft.Json;


public class TopPlaylistHighqualityRequestModel
{
    /// <summary>
    /// The playlist category. Defaults to "All".
    /// </summary>
    [JsonProperty("cat")]
    public string Cat { get; set; } = "È«²¿";

    /// <summary>
    /// The maximum number of playlists to retrieve. Defaults to 50.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 50;

    /// <summary>
    /// The timestamp of the last update for pagination. Defaults to 0.
    /// </summary>
    [JsonProperty("lasttime")]
    public long LastTime { get; set; } = 0;

    /// <summary>
    /// Indicates whether to include the total number of results. Defaults to true.
    /// </summary>
    [JsonProperty("total")]
    public bool Total { get; set; } = true;
}


