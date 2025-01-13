
using Newtonsoft.Json;

public class TopListRequestModel
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("n")]
    public string N { get; set; }
    [JsonProperty("s")]
    public string S { get; set; }
}
