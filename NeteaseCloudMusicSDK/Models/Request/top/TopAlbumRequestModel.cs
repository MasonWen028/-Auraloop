using Newtonsoft.Json;
using System;

public class TopAlbumRequestModel
{
    [JsonProperty("area")]
    public string Area { get; set; } = "ALL";

    [JsonProperty("limit")]
    public int Limit { get; set; } = 50;

    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;

    [JsonProperty("type")]
    public string Type { get; set; } = "new";

    [JsonProperty("year")]
    public int Year { get; set; } = DateTime.Now.Year;

    [JsonProperty("month")]
    public int Month { get; set; } = DateTime.Now.Month;
}
