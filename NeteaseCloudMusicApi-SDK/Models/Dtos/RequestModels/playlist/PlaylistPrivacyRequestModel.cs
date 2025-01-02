
using Newtonsoft.Json;

public class PlaylistPrivacyRequestModel
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("privacy")]
    public int Privacy { get; set; }
}
