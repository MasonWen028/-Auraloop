
using Newtonsoft.Json;

public class PlaylistSubscribeRequestModel
{
    [JsonProperty("id")]
    public long Id { get; set; }
}


public enum SubOpType
{
    subscribe = 1,
    unsubscribe = 2
}