using Newtonsoft.Json;

public class PaginatedRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; } = 20;

    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;

    [JsonProperty("total")]
    public bool Total { get; set; } = true;
}
