
using Newtonsoft.Json;

public class AlbumSongsaleboardRequestModel
{
    [JsonProperty("albumType")]
    public int AlbumType { get; set; }

    [JsonProperty("year")]
    public string Year { get; set; }

}
