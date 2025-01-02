
using Newtonsoft.Json;

public class CommentNewRequestModel
{
    [JsonProperty("threadId")]
    public string ThreadId { get; set; }
    [JsonProperty("pageNo")]
    public int PageNo { get; set; }
    [JsonProperty("showInner")]
    public bool ShowInner { get; set; }
    [JsonProperty("pageSize")]
    public int PageSize { get; set; }
    [JsonProperty("cursor")]
    public string Cursor { get; set; }
    [JsonProperty("sortType")]
    public string SortType { get; set; }
}
