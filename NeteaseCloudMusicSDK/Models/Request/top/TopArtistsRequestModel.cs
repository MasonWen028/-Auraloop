
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
    Chinese = 7,      // Chinese (����)
    Western = 96,     // Western (ŷ��)
    Korean = 16,      // Korean (����)
    Japanese = 8      // Japanese (�ձ�)
}

