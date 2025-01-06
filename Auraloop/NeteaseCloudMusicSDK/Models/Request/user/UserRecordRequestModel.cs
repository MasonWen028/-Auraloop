
using Newtonsoft.Json;

public class UserRecordRequestModel
{
    [JsonProperty("uid")]
    public string Uid { get; set; }
    [JsonProperty("type")]
    public int Type { get; set; }
}
