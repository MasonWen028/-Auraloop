
using Newtonsoft.Json;

public class MvAllRequestModel
{
    [JsonProperty("tags")]
    public string Tags { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("Limit")]
    public int Limit { get; set; }
    [JsonProperty("total")]
    public bool Total { get; set; }   
}

public enum Area
{
    全部,   // All
    内地,   // Mainland
    港台,   // Hong Kong and Taiwan
    欧美,   // Europe and America
    日本,   // Japan
    韩国    // Korea
}


public enum Type
{
    全部,   // All
    官方版, // Official Version
    原生,   // Original
    现场版, // Live Version
    网易出品 // Produced by NetEase
}


public enum Order
{
    上升最快, // Fastest Rising
    最热,     // Hottest
    最新      // Latest
}

