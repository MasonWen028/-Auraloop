
using Newtonsoft.Json;

public class SongWikiSummaryRequestModel
{
    [JsonProperty("songId")]
    public string SongId { get; set; }
}
