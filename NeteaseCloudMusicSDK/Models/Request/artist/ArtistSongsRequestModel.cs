
using Newtonsoft.Json;

public class ArtistSongsRequestModel
{
    [JsonProperty("id")]
    public long ArtistId { get; set; }

    [JsonProperty("private_cloud")]
    public string PrivateCloud { get; set; } = "true";

    [JsonProperty("work_type")]
    public int WorkType { get; set; } = 1;

    [JsonProperty("order")]
    public string Order { get; set; } = "hot"; // "hot" or "time"

    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;

    [JsonProperty("limit")]
    public int Limit { get; set; } = 100;
}
