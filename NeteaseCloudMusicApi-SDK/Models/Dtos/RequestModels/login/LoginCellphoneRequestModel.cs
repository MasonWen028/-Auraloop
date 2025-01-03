
using Newtonsoft.Json;

public class LoginCellphoneRequestModel
{
    /// <summary>
    /// The phone number of the user.
    /// </summary>
    [JsonProperty("phone")]
    public string Phone { get; set; }

    /// <summary>
    /// The country code for the user's phone number.
    /// </summary>
    [JsonProperty("countrycode")]
    public string CountryCode { get; set; }

    /// <summary>
    /// The CAPTCHA entered by the user (if available).
    /// </summary>
    [JsonProperty("captcha")]
    public string? Captcha { get; set; }

    /// <summary>
    /// The MD5 hash of the user's password (optional).
    /// </summary>
    [JsonProperty("md5_password")]
    public string? Md5Password { get; set; }

    /// <summary>
    /// The plain text password entered by the user.
    /// </summary>
    [JsonProperty("password")]
    public string? Password { get; set; }
}
