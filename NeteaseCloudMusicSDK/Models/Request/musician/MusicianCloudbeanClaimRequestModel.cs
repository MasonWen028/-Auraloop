using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to claim Cloudbeans for the musician.
/// </summary>
public class MusicianCloudbeanClaimRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the mission.
    /// </summary>
    [JsonProperty("userMissionId")]
    public long MissionId { get; set; }

    /// <summary>
    /// Gets or sets the period for which Cloudbeans are being claimed.
    /// </summary>
    [JsonProperty("period")]
    public string Period { get; set; }
}
