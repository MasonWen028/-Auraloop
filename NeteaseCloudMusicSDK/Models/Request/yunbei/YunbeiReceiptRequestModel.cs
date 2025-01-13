
using Newtonsoft.Json;

public class YunbeiReceiptRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; } = 10;
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;
}
