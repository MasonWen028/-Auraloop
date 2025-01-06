using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve users with similar music tastes.
/// </summary>
public class SimiUserRequestModel
{
    [JsonProperty("songid")]
    public long SongId { get; set; }

    [JsonProperty("limit")]
    public int Limit { get; set; } = 50;

    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;
}
