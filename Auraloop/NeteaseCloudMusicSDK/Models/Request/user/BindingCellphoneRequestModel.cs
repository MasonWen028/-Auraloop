using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to bind a phone number to the user's account.
/// </summary>
public class BindingCellphoneRequestModel
{
    [JsonProperty("phone")]
    public string Phone { get; set; }

    [JsonProperty("countrycode")]
    public string CountryCode { get; set; } = "86";

    [JsonProperty("captcha")]
    public string Captcha { get; set; }

    [JsonProperty("password")]
    public string Password { get; set; } = "";
}
