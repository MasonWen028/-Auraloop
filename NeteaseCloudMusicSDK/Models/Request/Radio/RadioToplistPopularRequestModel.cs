using Newtonsoft.Json;

public class RadioToplistPopularRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; } = 100;
}
