
using Newtonsoft.Json;

public class ListentogetherAcceptRequestModel
{
    [JsonProperty("refer")]
    public string Refer { get; set; }
    [JsonProperty("roomId")]
    public string RoomId { get; set; }
    [JsonProperty("inviterId")]
    public string InviterId { get; set; }
}
