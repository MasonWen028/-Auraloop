
using Newtonsoft.Json;

public class DigitalAlbumSalesRequestModel
{
    [JsonProperty("albumIds")]
    public string AlbumIds { get; set; }
}
