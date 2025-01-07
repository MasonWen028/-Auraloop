using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required for logging in using a cellphone.
/// </summary>
public class LoginCellphoneRequestModel
{
    /// <summary>
    /// Gets or sets the cellphone number for login.
    /// </summary>
    [JsonProperty("phone")]
    public string Phone { get; set; }

    /// <summary>
    /// Gets or sets the country code for the cellphone. Default is "86".
    /// </summary>
    [JsonProperty("countrycode")]
    public string CountryCode { get; set; } = "86";

    /// <summary>
    /// Gets or sets the password or verification code for login.
    /// </summary>
    [JsonProperty("password")]
    public string PasswordOrCaptcha { get; set; }
}
