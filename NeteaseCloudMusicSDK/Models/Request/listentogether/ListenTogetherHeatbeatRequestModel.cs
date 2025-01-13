using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to send a heartbeat signal in a "Listen Together" session.
/// </summary>
public class ListenTogetherHeartbeatRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the room.
    /// </summary>
    [JsonProperty("roomId")]
    public long RoomId { get; set; }

    /// <summary>
    /// Gets or sets the ID of the song being played.
    /// </summary>
    [JsonProperty("songId")]
    public long SongId { get; set; }

    /// <summary>
    /// Gets or sets the play status (e.g., playing, paused).
    /// </summary>
    [JsonProperty("playStatus")]
    public string PlayStatus { get; set; }

    /// <summary>
    /// Gets or sets the playback progress in seconds.
    /// </summary>
    [JsonProperty("progress")]
    public int Progress { get; set; }
}
