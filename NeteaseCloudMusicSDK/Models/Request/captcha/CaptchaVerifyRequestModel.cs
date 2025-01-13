
using Newtonsoft.Json;

public class CaptchaVerifyRequestModel
{
    [JsonProperty("ctcode")]
    public string Ctcode { get; set; } = "86";
    [JsonProperty("cellphone")]
    public string Cellphone { get; set; }
    [JsonProperty("captcha")]
    public string Captcha { get; set; }
}
