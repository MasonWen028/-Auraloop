
using Newtonsoft.Json;

public class CommentHugListRequestModel
{
    [JsonProperty("targetUserId")]
    public string TargetUserId { get; set; }
    [JsonProperty("commentId")]
    public string CommentId { get; set; }
    [JsonProperty("cursor")]
    public string Cursor { get; set; }
    [JsonProperty("threadId")]
    public string ThreadId { get; set; }
    [JsonProperty("pageNo")]
    public int PageNo { get; set; }
    [JsonProperty("idCursor")]
    public int IdCursor { get; set; }
    [JsonProperty("pageSize")]
    public int PageSize { get; set; }
}
