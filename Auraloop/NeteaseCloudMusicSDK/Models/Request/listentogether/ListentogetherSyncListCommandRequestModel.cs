
using Newtonsoft.Json;

public class ListentogetherSyncListCommandRequestModel
{
    [JsonProperty("roomId")]
    public string RoomId { get; set; }
    [JsonProperty("playlistParam")]
    public string PlaylistParam { get; set; }
    [JsonProperty("version")]
    public string Version { get; set; }
}
