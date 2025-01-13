using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve an annual listening summary.
/// </summary>
public class SummaryAnnualRequestModel
{
    /// <summary>
    /// Gets or sets the year for which to retrieve the summary.
    /// </summary>
    [JsonProperty("year")]
    public int Year { get; set; }
}
