
using Newtonsoft.Json;

public class RegisterCellphoneRequestModel
{
    [JsonProperty("captcha")]
    public string Captcha { get; set; }
    [JsonProperty("phone")]
    public string Phone { get; set; }
    [JsonProperty("password")]
    public string Password { get; set; }
    [JsonProperty("nickname")]
    public string Nickname { get; set; }
    [JsonProperty("countrycode")]
    public int Countrycode { get; set; }
}
