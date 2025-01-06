
using Newtonsoft.Json;

public class ListentogetherPlayCommandRequestModel
{
    [JsonProperty("roomId")]
    public string RoomId { get; set; }
    [JsonProperty("commandInfo")]
    public string CommandInfo { get; set; }
    [JsonProperty("progress")]
    public int Progress { get; set; }
    [JsonProperty("playStatus")]
    public string PlayStatus { get; set; }
    [JsonProperty("formerSongId")]
    public string FormerSongId { get; set; }
    [JsonProperty("targetSongId")]
    public string TargetSongId { get; set; }
    [JsonProperty("clientSeq")]
    public string ClientSeq { get; set; }
}
