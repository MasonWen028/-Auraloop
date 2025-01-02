
using Newtonsoft.Json;

public class RecordRecentAlbumRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; }
}
