using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to edit the user's social status.
/// </summary>
public class UserSocialStatusEditRequestModel
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("iconUrl")]
    public string IconUrl { get; set; }

    [JsonProperty("content")]
    public string Content { get; set; }

    [JsonProperty("actionUrl")]
    public string ActionUrl { get; set; }
}
