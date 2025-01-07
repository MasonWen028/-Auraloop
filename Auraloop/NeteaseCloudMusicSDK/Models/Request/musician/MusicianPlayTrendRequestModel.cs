
using Newtonsoft.Json;


/// <summary>
/// Represents the parameters required to retrieve play trend data for a musician's tracks.
/// </summary>
public class MusicianPlayTrendRequestModel
{
    /// <summary>
    /// Gets or sets the start time for the play trend data in milliseconds since epoch.
    /// </summary>
    [JsonProperty("startTime")]
    public long StartTime { get; set; }

    /// <summary>
    /// Gets or sets the end time for the play trend data in milliseconds since epoch.
    /// </summary>
    [JsonProperty("endTime")]
    public long EndTime { get; set; }
}
