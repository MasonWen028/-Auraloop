
using Newtonsoft.Json;

public class ListentogetherHeatbeatRequestModel
{
    [JsonProperty("roomId")]
    public string RoomId { get; set; }
    [JsonProperty("songId")]
    public string SongId { get; set; }
    [JsonProperty("playStatus")]
    public string PlayStatus { get; set; }
    [JsonProperty("progress")]
    public string Progress { get; set; }
}
