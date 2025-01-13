
using Newtonsoft.Json;

public class YunbeiRcmdSongRequestModel
{
    [JsonProperty("songId")]
    public string SongId { get; set; }
    [JsonProperty("reason")]
    public string Reason { get; set; }
    [JsonProperty("scene")]
    public string Scene { get; set; }
    [JsonProperty("fromUserId")]
    public int FromUserId { get; set; }
    [JsonProperty("yunbeiNum")]
    public int YunbeiNum { get; set; }
}
