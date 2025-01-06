
using Newtonsoft.Json;


public class TopPlaylistHighqualityRequestModel
{
    /// <summary>
    /// The playlist category. Defaults to "All".
    /// </summary>
    [JsonProperty("cat")]
    public string Cat { get; set; } = "È«²¿";

    /// <summary>
    /// The maximum number of playlists to retrieve. Defaults to 50.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 50;

    /// <summary>
    /// The timestamp of the last update for pagination. Defaults to 0.
    /// </summary>
    [JsonProperty("lasttime")]
    public long LastTime { get; set; } = 0;

    /// <summary>
    /// Indicates whether to include the total number of results. Defaults to true.
    /// </summary>
    [JsonProperty("total")]
    public bool Total { get; set; } = true;
}

public enum PlaylistCategory
{
    All,           // All playlists
    Chinese,       // Chinese music
    Western,       // Western music
    Korean,        // Korean music
    Japanese,      // Japanese music
    Cantonese,     // Cantonese music
    MinorLanguages, // Minor languages
    Sports,        // Sports-related playlists
    ACG,           // Anime, Comic, and Games
    Soundtrack,    // Movie soundtracks
    Pop,           // Pop music
    Rock,          // Rock music
    PostRock,      // Post-rock music
    AncientStyle,  // Ancient/traditional style
    Folk,          // Folk music
    LightMusic,    // Light/instrumental music
    Electronic,    // Electronic music
    Instrumental,  // Instrumental music
    Rap,           // Rap music
    Classical,     // Classical music
    Jazz           // Jazz music
}

