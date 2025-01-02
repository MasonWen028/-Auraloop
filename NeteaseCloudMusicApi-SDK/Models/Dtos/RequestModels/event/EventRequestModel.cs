
using Newtonsoft.Json;

public class EventRequestModel
{
    [JsonProperty("pagesize")]
    public int Pagesize { get; set; }
    [JsonProperty("lasttime")]
    public long Lasttime { get; set; }
}
