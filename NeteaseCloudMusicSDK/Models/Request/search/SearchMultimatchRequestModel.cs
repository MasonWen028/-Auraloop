
using Newtonsoft.Json;

public class SearchMultimatchRequestModel
{
    [JsonProperty("type")]
    public int Type { get; set; }
    [JsonProperty("s")]
    public string S { get; set; }
}
