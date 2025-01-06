
using Newtonsoft.Json;

public class DjToplistRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
}


public enum ListType
{
    @new = 0, // new list
    hot = 1   // hot list
}