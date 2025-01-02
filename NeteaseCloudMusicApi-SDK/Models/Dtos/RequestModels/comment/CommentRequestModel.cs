
using Newtonsoft.Json;

public class CommentRequestModel
{
    [JsonProperty("threadId")]
    public string ThreadId { get; set; }
}
