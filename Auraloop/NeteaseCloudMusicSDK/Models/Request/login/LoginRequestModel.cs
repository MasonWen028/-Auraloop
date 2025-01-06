
using Newtonsoft.Json;

public class LoginRequestModel
{
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("https")]
    public string Https { get; set; }
    [JsonProperty("username")]
    public string Username { get; set; }
    [JsonProperty("password")]
    public string Password { get; set; }
    [JsonProperty("rememberLogin")]
    public string RememberLogin { get; set; }
}
