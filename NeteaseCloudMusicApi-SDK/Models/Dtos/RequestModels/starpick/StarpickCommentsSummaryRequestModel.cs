
using Newtonsoft.Json;

public class StarpickCommentsSummaryRequestModel
{
    [JsonProperty("cursor")]
    public string Cursor { get; set; }
    [JsonProperty("blockCodeOrderList")]
    public string BlockCodeOrderList { get; set; }
    [JsonProperty("refresh")]
    public bool Refresh { get; set; }
}
