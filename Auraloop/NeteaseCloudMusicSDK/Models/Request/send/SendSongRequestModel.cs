using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to send a song as a private message.
/// </summary>
public class SendSongRequestModel
{
    [JsonProperty("id")]
    public string SongId { get; set; }

    [JsonProperty("msg")]
    public string Message { get; set; } = "";

    [JsonProperty("userIds")]
    public string[] UserIds { get; set; }
}
