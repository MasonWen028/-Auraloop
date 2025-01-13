using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve Yunbei recommended song history.
/// </summary>
public class YunbeiRcmdSongHistoryRequestModel
{
    [JsonProperty("page")]
    public YunbeiRcmdSongHistoryPage Page { get; set; } // it should be the json string of an instance of YunbeiRcmdSongHistoryPage

}

public class YunbeiRcmdSongHistoryPage
{
    [JsonProperty("size")]
    public int Size { get; set; } = 20;

    [JsonProperty("cursor")]
    public string Cursor { get; set; } = "";
}
