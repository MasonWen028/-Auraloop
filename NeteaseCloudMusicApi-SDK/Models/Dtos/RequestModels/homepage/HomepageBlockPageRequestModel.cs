
using Newtonsoft.Json;

public class HomepageBlockPageRequestModel
{
    [JsonProperty("refresh")]
    public bool Refresh { get; set; }
    [JsonProperty("cursor")]
    public string Cursor { get; set; }
}
