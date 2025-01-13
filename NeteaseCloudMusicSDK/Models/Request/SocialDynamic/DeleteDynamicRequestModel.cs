using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to delete a dynamic.
/// </summary>
public class DeleteDynamicRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the dynamic to delete.
    /// </summary>
    [JsonProperty("id")]
    public long DynamicId { get; set; }
}
