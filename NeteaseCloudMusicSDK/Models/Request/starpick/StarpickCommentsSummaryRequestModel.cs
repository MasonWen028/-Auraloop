using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve a summary of Starpick comments.
/// </summary>
public class StarpickCommentsSummaryRequestModel
{
    /// <summary>
    /// Gets or sets the cursor details, including offset, block codes, and refresh flag.
    /// </summary>
    [JsonProperty("cursor")]
    public StarpickCursor Cursor { get; set; } = new StarpickCursor();
}

/// <summary>
/// Represents the cursor details for Starpick comments summary.
/// </summary>
public class StarpickCursor
{
    /// <summary>
    /// Gets or sets the offset for pagination.
    /// </summary>
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;

    /// <summary>
    /// Gets or sets the block code order list for filtering comments.
    /// </summary>
    [JsonProperty("blockCodeOrderList")]
    public string[] BlockCodeOrderList { get; set; } = { "HOMEPAGE_BLOCK_NEW_HOT_COMMENT" };

    /// <summary>
    /// Gets or sets a value indicating whether to refresh the data.
    /// </summary>
    [JsonProperty("refresh")]
    public bool Refresh { get; set; } = true;
}
