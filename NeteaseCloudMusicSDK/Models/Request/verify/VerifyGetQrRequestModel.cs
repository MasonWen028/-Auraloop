using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to generate a QR code for user verification.
/// </summary>
public class VerifyGetQrRequestModel
{
    /// <summary>
    /// Gets or sets the verification configuration ID.
    /// </summary>
    [JsonProperty("verifyConfigId")]
    public string VerifyConfigId { get; set; }

    /// <summary>
    /// Gets or sets the verification type.
    /// </summary>
    [JsonProperty("verifyType")]
    public string VerifyType { get; set; }

    /// <summary>
    /// Gets or sets the token associated with the verification process.
    /// </summary>
    [JsonProperty("token")]
    public string Token { get; set; }

    /// <summary>
    /// Gets or sets additional parameters for verification, such as event ID and signature.
    /// </summary>
    [JsonProperty("params")]
    public VerifyQrParams Params { get; set; }

    /// <summary>
    /// Gets or sets the size of the QR code. Default is 150.
    /// </summary>
    [JsonProperty("size")]
    public int Size { get; set; } = 150;
}

/// <summary>
/// Represents additional parameters for the QR code generation process.
/// </summary>
public class VerifyQrParams
{
    /// <summary>
    /// Gets or sets the event ID.
    /// </summary>
    [JsonProperty("event_id")]
    public string EventId { get; set; }

    /// <summary>
    /// Gets or sets the signature associated with the verification process.
    /// </summary>
    [JsonProperty("sign")]
    public string Sign { get; set; }
}
