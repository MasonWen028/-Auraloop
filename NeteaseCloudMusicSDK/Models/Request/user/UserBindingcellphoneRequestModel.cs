
using Newtonsoft.Json;

public class UserBindingcellphoneRequestModel
{
    [JsonProperty("phone")]
    public string Phone { get; set; }
    [JsonProperty("countrycode")]
    public int Countrycode { get; set; }
    [JsonProperty("captcha")]
    public string Captcha { get; set; }
    [JsonProperty("password")]
    public string Password { get; set; }
}
