
using Newtonsoft.Json;

public class UserReplacephoneRequestModel
{
    [JsonProperty("phone")]
    public string Phone { get; set; }
    [JsonProperty("captcha")]
    public string Captcha { get; set; }
    [JsonProperty("oldcaptcha")]
    public string Oldcaptcha { get; set; }
    [JsonProperty("countrycode")]
    public int Countrycode { get; set; }
}
