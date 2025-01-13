
using Newtonsoft.Json;

public class UserRadiosRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }

    [JsonIgnore]
    public string Uid { get; set; }
}
