using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to send a text message as a private message.
/// </summary>
public class SendTextRequestModel
{
    [JsonProperty("msg")]
    public string Message { get; set; }

    [JsonProperty("userIds")]
    public string[] UserIds { get; set; }

    const string type = "text";
}
