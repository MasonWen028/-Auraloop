using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to query sign-in progress.
/// </summary>
public class SigninProgressRequestModel
{
    /// <summary>
    /// Gets or sets the module ID for which to query sign-in progress.
    /// Default is "1207signin-1207signin".
    /// </summary>
    [JsonProperty("moduleId")]
    public string ModuleId { get; set; } = "1207signin-1207signin";
}
