using Newtonsoft.Json;

public class RadioLikeRequestModel
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("like")]
    public bool Like { get; set; }
}
