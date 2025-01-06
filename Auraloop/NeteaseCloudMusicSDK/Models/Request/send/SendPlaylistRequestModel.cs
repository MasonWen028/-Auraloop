using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to send a playlist as a private message.
/// </summary>
public class SendPlaylistRequestModel
{
    [JsonProperty("id")]
    public string PlaylistId { get; set; }

    [JsonProperty("msg")]
    public string Message { get; set; }

    [JsonProperty("userIds")]
    public string[] UserIds { get; set; }
}
