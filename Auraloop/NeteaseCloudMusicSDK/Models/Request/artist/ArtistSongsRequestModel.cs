
using Newtonsoft.Json;

public class ArtistSongsRequestModel
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("private_cloud")]
    public string PrivateCloud { get; set; }
    [JsonProperty("work_type")]
    public int WorkType { get; set; }
    [JsonProperty("order")]
    public string Order { get; set; } = "hot";
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
}
