
using Newtonsoft.Json;

public class MvDetailInfoRequestModel
{
    [JsonProperty("threadid")]
    public string Threadid { get; set; }

    [JsonProperty("composeliked")]
    public bool Composeliked { get; set; } = true;
}
