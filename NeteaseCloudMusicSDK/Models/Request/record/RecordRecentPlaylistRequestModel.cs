
using Newtonsoft.Json;

public class RecordRecentPlaylistRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; }
}
