
using Newtonsoft.Json;

public class TopSongRequestModel
{
    [JsonProperty("areaId")]
    public int AreaId { get; set; }
    [JsonProperty("total")]
    public bool Total { get; set; }
}
