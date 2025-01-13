
using Newtonsoft.Json;

public class CommentHugListRequestModel
{
    [JsonProperty("targetUserId")]
    public string TargetUserId { get; set; }
    [JsonProperty("commentId")]
    public string CommentId { get; set; }
    [JsonProperty("cursor")]
    public string Cursor { get; set; } = "-1";
    [JsonProperty("threadId")]
    public string ThreadId { get; set; }
    [JsonProperty("pageNo")]
    public int PageNo { get; set; } = 1;
    [JsonProperty("idCursor")]
    public int IdCursor { get; set; } = -1;
    [JsonProperty("pageSize")]
    public int PageSize { get; set; } = 100;
}
