using Newtonsoft.Json;

public class VideoCategoryListRequestModel
{
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;

    [JsonProperty("limit")]
    public int Limit { get; set; } = 99;

    [JsonProperty("total")]
    public bool Total { get; set; } = true;
}
