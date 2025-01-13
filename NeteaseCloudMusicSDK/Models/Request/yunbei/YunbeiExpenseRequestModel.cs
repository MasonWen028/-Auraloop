
using Newtonsoft.Json;

public class YunbeiExpenseRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; } = 10;
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;
}
