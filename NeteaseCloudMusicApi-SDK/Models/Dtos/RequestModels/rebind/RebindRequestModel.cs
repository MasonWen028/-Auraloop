
using Newtonsoft.Json;

public class RebindRequestModel
{
    [JsonProperty("captcha")]
    public string Captcha { get; set; }
    [JsonProperty("phone")]
    public string Phone { get; set; }
    [JsonProperty("oldcaptcha")]
    public string Oldcaptcha { get; set; }
    [JsonProperty("ctcode")]
    public string Ctcode { get; set; }
}
