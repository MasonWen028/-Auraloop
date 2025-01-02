
using Newtonsoft.Json;

public class PersonalizedNewsongRequestModel
{
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("areaId")]
    public int AreaId { get; set; }
}
