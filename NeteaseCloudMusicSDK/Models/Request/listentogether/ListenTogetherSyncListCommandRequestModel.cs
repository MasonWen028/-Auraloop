using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to synchronize commands in a "Listen Together" session.
/// </summary>
public class ListenTogetherSyncCommandRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the room.
    /// </summary>
    [JsonProperty("roomId")]
    public long RoomId { get; set; }

    /// <summary>
    /// Gets or sets the playlist synchronization parameters in JSON format.
    /// </summary>
    [JsonProperty("playlistParam")]
    public string PlaylistParam { get; set; }
}
