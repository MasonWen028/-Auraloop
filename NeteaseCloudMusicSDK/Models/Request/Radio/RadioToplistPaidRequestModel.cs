using Newtonsoft.Json;

public class RadioToplistPaidRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; } = 100;
}
