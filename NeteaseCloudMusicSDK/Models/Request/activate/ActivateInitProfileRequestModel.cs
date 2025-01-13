using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to initialize the user's profile.
/// </summary>
public class ActivateInitProfileRequestModel
{
    [JsonProperty("nickname")]
    public string Nickname { get; set; }
}
