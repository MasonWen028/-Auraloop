
using Newtonsoft.Json;

public class UserCommentHistoryRequestModel
{
    [JsonProperty("compose_reminder")]
    public string ComposeReminder { get; set; }
    [JsonProperty("compose_hot_comment")]
    public string ComposeHotComment { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("user_id")]
    public string UserId { get; set; }
    [JsonProperty("time")]
    public long Time { get; set; }
}
