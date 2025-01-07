using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to change the Personal FM mode.
/// </summary>
public class PersonalFmModeRequestModel
{
    /// <summary>
    /// Gets or sets the mode of Personal FM, such as "DEFAULT", "FAMILIAR", "EXPLORE", or "SCENE_RCMD".
    /// </summary>
    [JsonProperty("mode")]
    public string Mode { get; set; }

    /// <summary>
    /// Gets or sets the submode for more granular customization, such as "EXERCISE" or "FOCUS".
    /// </summary>
    [JsonProperty("subMode")]
    public string SubMode { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of recommendations to retrieve. Default is 3.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 3;
}
