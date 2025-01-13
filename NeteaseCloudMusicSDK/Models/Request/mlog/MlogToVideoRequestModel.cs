using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to convert an Mlog post to a video format.
/// </summary>
public class MlogToVideoRequestModel
{
    /// <summary>
    /// Gets or sets the Mlog ID to convert.
    /// </summary>
    [JsonProperty("mlogId")]
    public long MlogId { get; set; }
}
