using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to update the user's profile.
/// </summary>
public class UserUpdateRequestModel
{
    [JsonProperty("nickname")]
    public string Nickname { get; set; }

    [JsonProperty("signature")]
    public string Signature { get; set; }

    [JsonProperty("gender")]
    public int Gender { get; set; } // 0: Unknown, 1: Male, 2: Female

    [JsonProperty("birthday")]
    public long Birthday { get; set; }

    [JsonProperty("city")]
    public int City { get; set; }

    [JsonProperty("province")]
    public int Province { get; set; }
}
