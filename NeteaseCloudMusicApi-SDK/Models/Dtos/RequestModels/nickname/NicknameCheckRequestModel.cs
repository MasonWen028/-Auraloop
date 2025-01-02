
using Newtonsoft.Json;

public class NicknameCheckRequestModel
{
    [JsonProperty("nickname")]
    public string Nickname { get; set; }
}
