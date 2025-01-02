
using Newtonsoft.Json;

public class MusicianCloudbeanObtainRequestModel
{
    [JsonProperty("userMissionId")]
    public string UserMissionId { get; set; }
    [JsonProperty("period")]
    public string Period { get; set; }
}
