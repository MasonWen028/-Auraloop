
using Newtonsoft.Json;

public class DjProgramRequestModel
{
    [JsonProperty("radioId")]
    public string RadioId { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("asc")]
    public string Asc { get; set; }
}
