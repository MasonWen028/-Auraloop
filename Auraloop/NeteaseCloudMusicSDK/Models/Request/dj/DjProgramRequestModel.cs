
using Newtonsoft.Json;

public class DjProgramRequestModel
{
    [JsonProperty("radioId")]
    public long RadioId { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("asc")]
    public bool Asc { get; set; }
}
