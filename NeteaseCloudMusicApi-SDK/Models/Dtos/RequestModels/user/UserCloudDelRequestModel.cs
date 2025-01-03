
using Newtonsoft.Json;

public class UserCloudDelRequestModel
{
    [JsonProperty("songIds")]
    public long[] SongIds { get; set; }
}
