
using Newtonsoft.Json;

public class TopArtistsRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("total")]
    public bool Total { get; set; }
    [JsonProperty("areaId")]
    public MusicRegion AreaId { get; set; }
}

public enum MusicRegion
{
    All = 0,          // All regions
    Chinese = 7,      // Chinese (华语)
    Western = 96,     // Western (欧美)
    Korean = 16,      // Korean (韩国)
    Japanese = 8      // Japanese (日本)
}

