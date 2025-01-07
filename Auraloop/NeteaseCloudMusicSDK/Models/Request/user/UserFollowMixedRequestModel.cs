using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve mixed follow lists.
/// </summary>
public class UserFollowMixedRequestModel
{
    [JsonProperty("size")]
    public int Size { get; set; } = 30;

    [JsonProperty("cursor")]
    public int Cursor { get; set; } = 0;

    [JsonProperty("scene")]
    public int Scene { get; set; } = 0; // 0: All, 1: Artists, 2: Users
}
