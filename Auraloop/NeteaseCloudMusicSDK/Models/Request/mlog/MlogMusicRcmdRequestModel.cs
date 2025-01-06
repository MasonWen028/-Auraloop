
using Newtonsoft.Json;

public class MlogMusicRcmdRequestModel
{
    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("type")]
    public int Type { get; set; }
    [JsonProperty("rcmdType")]
    public int RcmdType { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("extInfo")]
    public string ExtInfo { get; set; }
}
