using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to order a digital album.
/// </summary>
public class DigitalAlbumOrderRequestModel
{
    /// <summary>
    /// Gets or sets the payment method for the order.
    /// </summary>
    [JsonProperty("paymentMethod")]
    public string PaymentMethod { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the digital album.
    /// </summary>
    [JsonProperty("resourceID")]
    public long AlbumId { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the digital album to order. Default is 1.
    /// </summary>
    [JsonProperty("quantity")]
    public int Quantity { get; set; } = 1;

    /// <summary>
    /// Gets or sets the source of the order request. Default is "web".
    /// </summary>
    [JsonProperty("from")]
    public string From { get; set; } = "web";

    /// <summary>
    /// json string of DigitalResource list
    /// </summary>
    [JsonProperty("digitalResources")]
    public string DigitalResources { get; set; } = "";

    /// <summary>
    /// business type
    /// </summary>
    public string Business { get; set; } = "Album";
}

public class DigitalResource
{
    public const string Business = "Album";

    [JsonProperty("resourceID")]
    public long ResourceID { get; set; }

    [JsonProperty("quantity")]
    public long Quantity { get; set; }
}
