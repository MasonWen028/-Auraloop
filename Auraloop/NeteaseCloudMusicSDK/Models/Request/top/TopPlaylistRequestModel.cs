using Newtonsoft.Json;

public class TopPlaylistRequestModel
{
    [JsonProperty("cat")]
    public string Category { get; set; } = "È«²¿";

    [JsonProperty("order")]
    public string Order { get; set; } = "hot";

    [JsonProperty("limit")]
    public int Limit { get; set; } = 50;

    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;
}
