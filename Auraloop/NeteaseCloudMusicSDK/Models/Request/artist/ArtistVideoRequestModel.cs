
using Newtonsoft.Json;

public class ArtistVideoRequestModel
{
    [JsonProperty("artistId")]
    public string ArtistId { get; set; }
    [JsonProperty("page")]
    public int Page { get; set; }
    [JsonProperty("cursor")]
    public int Cursor { get; set; }
}
