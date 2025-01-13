using Newtonsoft.Json;

public class TopMvRequestModel
{
    [JsonProperty("area")]
    public string Area { get; set; } = "";

    [JsonProperty("limit")]
    public int Limit { get; set; } = 30;

    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;
}
