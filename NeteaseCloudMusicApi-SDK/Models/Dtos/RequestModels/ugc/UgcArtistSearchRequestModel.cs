
using Newtonsoft.Json;

public class UgcArtistSearchRequestModel
{
    [JsonProperty("keyword")]
    public string Keyword { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
}
