using Newtonsoft.Json;

public class RadioHotRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; } = 30;

    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;
}
