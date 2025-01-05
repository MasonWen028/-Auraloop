
using Newtonsoft.Json;

public class VideoDetailInfoRequestModel
{
    [JsonProperty("threadid")]
    public string Threadid { get; set; }

    [JsonProperty("composeliked")]
    public bool Composeliked { get; set; } = true;
}
