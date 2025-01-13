using Newtonsoft.Json;

public class VoiceUploadRequestModel
{
    [JsonProperty("songFile")]
    public byte[] SongFile { get; set; }

    [JsonProperty("songName")]
    public string SongName { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("voiceListId")]
    public long VoiceListId { get; set; }

    [JsonProperty("coverImgId")]
    public string CoverImgId { get; set; }

    [JsonProperty("categoryId")]
    public long CategoryId { get; set; }

    [JsonProperty("secondCategoryId")]
    public long SecondCategoryId { get; set; }

    [JsonProperty("autoPublish")]
    public bool AutoPublish { get; set; } = false;

    [JsonProperty("autoPublishText")]
    public string AutoPublishText { get; set; } = "";

    [JsonProperty("privacy")]
    public bool Privacy { get; set; } = false;

    [JsonProperty("publishTime")]
    public long PublishTime { get; set; } = 0;

    [JsonProperty("orderNo")]
    public int OrderNo { get; set; } = 1;

    [JsonProperty("composedSongs")]
    public string[] ComposedSongs { get; set; } = new string[0];
}
