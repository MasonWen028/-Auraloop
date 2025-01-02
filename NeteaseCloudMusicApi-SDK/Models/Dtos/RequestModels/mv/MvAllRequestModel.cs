
using Newtonsoft.Json;

public class MvAllRequestModel
{
    [JsonProperty("tags")]
    public string Tags { get; set; }
    [JsonProperty("类型")]
    public string 类型 { get; set; }
    [JsonProperty("排序")]
    public string 排序 { get; set; }
}
