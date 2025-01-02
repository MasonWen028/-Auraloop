
using Newtonsoft.Json;

public class UgcDetailRequestModel
{
    [JsonProperty("auditStatus")]
    public string AuditStatus { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("order")]
    public string Order { get; set; }
    [JsonProperty("sortBy")]
    public string SortBy { get; set; }
    [JsonProperty("type")]
    public int Type { get; set; }
}
