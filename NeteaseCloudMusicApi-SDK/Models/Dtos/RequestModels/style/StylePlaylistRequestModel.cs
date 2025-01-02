
using Newtonsoft.Json;

public class StylePlaylistRequestModel
{
    [JsonProperty("cursor")]
    public int Cursor { get; set; }
    [JsonProperty("size")]
    public int Size { get; set; }
    [JsonProperty("tagId")]
    public string TagId { get; set; }
    [JsonProperty("sort")]
    public int Sort { get; set; }
}
