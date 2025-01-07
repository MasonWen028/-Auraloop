using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Represents the parameters required for a batch request.
/// </summary>
public class BatchRequestModel
{
    /// <summary>
    /// Gets or sets a dictionary of API endpoint paths and their corresponding request data.
    /// The keys must start with "/api/".
    /// </summary>
    [JsonProperty("batchRequests")]
    public Dictionary<string, object> BatchRequests { get; set; } = new Dictionary<string, object>();
}
