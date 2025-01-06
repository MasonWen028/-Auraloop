
using Newtonsoft.Json;

public class YunbeiRcmdSongHistoryRequestModel
{
    [JsonProperty("page")]
    public int Page { get; set; }
    [JsonProperty("cursor")]
    public string Cursor { get; set; }
}
