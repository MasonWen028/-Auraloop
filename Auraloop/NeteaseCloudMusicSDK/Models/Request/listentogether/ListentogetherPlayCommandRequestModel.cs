using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to send a play command in a "Listen Together" session.
/// </summary>
public class ListenTogetherPlayCommandRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the room.
    /// </summary>
    [JsonProperty("roomId")]
    public long RoomId { get; set; }

    /// <summary>
    /// Gets or sets the command information in JSON format.
    /// </summary>
    [JsonProperty("commandInfo")]
    public string CommandInfo { get; set; }
}
