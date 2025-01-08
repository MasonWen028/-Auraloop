using Newtonsoft.Json;

public class ArtistVideoRequestModel
{
    [JsonProperty("artistId")]
    public long ArtistId { get; set; }

    [JsonProperty("page")]
    public PageInfo Page { get; set; } = new PageInfo();

    [JsonProperty("tab")]
    public int Tab { get; set; } = 0;

    [JsonProperty("order")]
    public int Order { get; set; } = 0;
}

public class PageInfo
{
    [JsonProperty("size")]
    public int Size { get; set; } = 10;

    [JsonProperty("cursor")]
    public int Cursor { get; set; } = 0;
}
