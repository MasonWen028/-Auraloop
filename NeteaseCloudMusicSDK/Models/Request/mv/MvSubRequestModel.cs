
using Newtonsoft.Json;

public class MvSubRequestModel
{
    [JsonProperty("mvId")]
    public string MvId { get; set; }
    [JsonProperty("mvIds")]
    public string MvIds { get; set; }
}
