using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to replace the user's phone number.
/// </summary>
public class UserReplacePhoneRequestModel
{
    [JsonProperty("phone")]
    public string Phone { get; set; }

    [JsonProperty("captcha")]
    public string Captcha { get; set; }

    [JsonProperty("oldcaptcha")]
    public string OldCaptcha { get; set; }

    [JsonProperty("countrycode")]
    public string CountryCode { get; set; } = "86";
}
