using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to update the user's profile.
/// </summary>
public class UserUpdateRequestModel
{
    /// <summary>
    /// Gets or sets the user's birthday as a Unix timestamp (in milliseconds).
    /// </summary>
    [JsonProperty("birthday")]
    public long Birthday { get; set; }

    /// <summary>
    /// Gets or sets the city ID where the user resides.
    /// </summary>
    [JsonProperty("city")]
    public int City { get; set; }

    /// <summary>
    /// Gets or sets the user's gender.
    /// 0: Unknown, 1: Male, 2: Female.
    /// </summary>
    [JsonProperty("gender")]
    public int Gender { get; set; }

    /// <summary>
    /// Gets or sets the user's nickname.
    /// </summary>
    [JsonProperty("nickname")]
    public string Nickname { get; set; }

    /// <summary>
    /// Gets or sets the province ID where the user resides.
    /// </summary>
    [JsonProperty("province")]
    public int Province { get; set; }

    /// <summary>
    /// Gets or sets the user's signature or status message.
    /// </summary>
    [JsonProperty("signature")]
    public string Signature { get; set; }
}
