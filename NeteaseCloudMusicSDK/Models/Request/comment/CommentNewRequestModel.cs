
using Newtonsoft.Json;

//public class CommentNewRequestModel
//{
//    [JsonProperty("threadId")]
//    public string ThreadId { get; set; }
//    [JsonProperty("pageNo")]
//    public int PageNo { get; set; }
//    [JsonProperty("showInner")]
//    public bool ShowInner { get; set; }
//    [JsonProperty("pageSize")]
//    public int PageSize { get; set; }
//    [JsonProperty("cursor")]
//    public string Cursor { get; set; }
//    [JsonProperty("sortType")]
//    public string SortType { get; set; }
//}

/// <summary>
/// Request model for fetching comments associated with a specific resource.
/// </summary>
public class CommentNewRequestModel
{
    /// <summary>
    /// The ID of the corresponding resource.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// The type of the corresponding resource.
    /// </summary>
    public ResourceType Type { get; set; }

    /// <summary>
    /// Pagination parameter, the page number to fetch. Default is 1.
    /// </summary>
    [JsonProperty("pageNo")]
    public int PageNo { get; set; } = 1;

    /// <summary>
    /// Pagination parameter, the number of items per page. Default is 20.
    /// </summary>
    [JsonProperty("pageSize")]
    public int PageSize { get; set; } = 20;

    /// <summary>
    /// Sorting type: 
    /// 99 - By recommendation (default),
    /// 2 - By popularity,
    /// 3 - By time.
    /// </summary>    
    [JsonProperty("sortType")]
    public int SortType { get; set; }

    /// <summary>
    /// When SortType is 3 and the page number is not the first page, 
    /// this value should be the time of the previous item.
    /// </summary>
    [JsonProperty("cursor")]
    public string Cursor { get; set; } = "";

    /// <summary>
    /// Whether to show inner comments. Defaults to true.
    /// </summary>
    [JsonProperty("showInner")]
    public bool ShowInner { get; set; } = true;

    [JsonProperty("threadId")]
    public string ThreadId { get; set; }
}

/// <summary>
/// Enumeration for the type of the corresponding resource.
/// </summary>
public enum ResourceType
{
    Song = 0,       // Song
    MV = 1,         // Music Video
    Playlist = 2,   // Playlist
    Album = 3,      // Album
    RadioShow = 4,  // Radio Show
    Video = 5,      // Video
    Post = 6,       // Dynamic Post
    Radio = 7,       // Radio
    
}

/// <summary>
/// Enumeration for sorting type.
/// </summary>
public enum SortType
{
    Popularity = 2,      // By popularity
    Time = 3,             // By time
    Recommendation = 99
}

