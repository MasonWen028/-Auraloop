using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to send an album as a private message.
/// </summary>
public class SendAlbumRequestModel
{
    [JsonProperty("id")]
    public string AlbumId { get; set; }

    [JsonProperty("msg")]
    public string Message { get; set; } = "";

    [JsonProperty("userIds")]
    public string[] UserIds { get; set; }
}
