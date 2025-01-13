
using Newtonsoft.Json;

public class RecordRecentSongRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; }
}
