
using Newtonsoft.Json;

public class PlaylistPrivacyRequestModel
{
    [JsonProperty("id")]
    public long Id { get; set; }
    [JsonProperty("privacy")]
    public int Privacy { get; set; }
}
