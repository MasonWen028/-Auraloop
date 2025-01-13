using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to fetch the URL of an Mlog post.
/// </summary>
public class MlogUrlRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the Mlog post.
    /// </summary>
    [JsonProperty("id")]
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the desired resolution for the Mlog post. Default is 1080.
    /// </summary>
    [JsonProperty("resolution")]
    public int Resolution { get; set; } = 1080;

    /// <summary>
    /// Gets or sets the type of the Mlog post. Default is 1.
    /// </summary>
    [JsonProperty("type")]
    public int Type { get; set; } = 1;
}
