
using Newtonsoft.Json;

public class UserUpdateRequestModel
{
    [JsonProperty("birthday")]
    public string Birthday { get; set; }
    [JsonProperty("city")]
    public string City { get; set; }
    [JsonProperty("gender")]
    public string Gender { get; set; }
    [JsonProperty("nickname")]
    public string Nickname { get; set; }
    [JsonProperty("province")]
    public string Province { get; set; }
    [JsonProperty("signature")]
    public string Signature { get; set; }
}
