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
    public ListenTogetherPlayCommandInfo CommandInfo { get; set; }
}

public class ListenTogetherPlayCommandInfo
{
    public int commandType { get; set; }

    public int progress { get; set; } = 0;

    public bool playStatus { get; set; }

    public long formerSongId { get; set; }

    public long targetSongId { get; set; }

    public string clientSeq { get; set; }
}
