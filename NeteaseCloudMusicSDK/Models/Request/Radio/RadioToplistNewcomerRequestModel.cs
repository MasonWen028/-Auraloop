﻿using Newtonsoft.Json;

public class RadioToplistNewcomerRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; } = 100;

    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;
}