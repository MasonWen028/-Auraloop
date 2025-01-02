
using Newtonsoft.Json;

public class SheetListRequestModel
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("abTest")]
    public string AbTest { get; set; }
}
