
using Newtonsoft.Json;
using System;

public class ArtistNewSongRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; } = 20;
    [JsonProperty("startTimestamp")]
    public long StartTimestamp { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
}
