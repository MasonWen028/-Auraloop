using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to accept an invitation to join a "Listen Together" session.
/// </summary>
public class ListenTogetherAcceptRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the room.
    /// </summary>
    [JsonProperty("roomId")]
    public long RoomId { get; set; }

    /// <summary>
    /// Gets or sets the ID of the inviter.
    /// </summary>
    [JsonProperty("inviterId")]
    public long InviterId { get; set; }

    /// <summary>
    /// Gets or sets the reference source for the invitation.
    /// </summary>
    [JsonProperty("refer")]
    public string Refer { get; set; } = "inbox_invite";
}
