
using Newtonsoft.Json;

public class LoginRequestModel
{
    /// <summary>
    /// type of login
    /// </summary>
    /// <example>0</example>
    [JsonProperty("type")]
    public string Type { get; set; } = "0";
    [JsonProperty("https")]
    public string Https { get; set; } = "true";
    /// <example>xxx@a.com.au</example>
    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("password")]
    public string Password { get; set; }
    [JsonProperty("rememberLogin")]
    public string RememberLogin { get; set; } = "true";
}
