
using Newtonsoft.Json;

public class SearchRequestModel
{
    [JsonProperty("keyword")]
    public string Keyword { get; set; }
    [JsonProperty("scene")]
    public string Scene { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
}
