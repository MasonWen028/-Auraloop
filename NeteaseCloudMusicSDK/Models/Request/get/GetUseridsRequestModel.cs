
using Newtonsoft.Json;

public class GetUseridsRequestModel
{
    [JsonProperty("nicknames")]
    public string Nicknames { get; set; }
}
