
using Newtonsoft.Json;

public class LoginCellphoneRequestModel
{
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("https")]
    public string Https { get; set; }
    [JsonProperty("phone")]
    public string Phone { get; set; }
    [JsonProperty("countrycode")]
    public int Countrycode { get; set; }
    [JsonProperty("captcha")]
    public string Captcha { get; set; }
    [JsonProperty("query")]
    public string Query { get; set; }
    [JsonProperty("password")]
    public string Password { get; set; }
    [JsonProperty("rememberLogin")]
    public string RememberLogin { get; set; }
}
