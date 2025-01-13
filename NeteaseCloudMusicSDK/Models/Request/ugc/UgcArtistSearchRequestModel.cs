using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to search for artists.
/// </summary>
public class UgcArtistSearchRequestModel
{
    /// <summary>
    /// Gets or sets the search keyword.
    /// </summary>
    [JsonProperty("keyword")]
    public string Keyword { get; set; }

    /// <summary>
    /// Gets or sets the number of results to retrieve. Default is 40.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 40;
}
