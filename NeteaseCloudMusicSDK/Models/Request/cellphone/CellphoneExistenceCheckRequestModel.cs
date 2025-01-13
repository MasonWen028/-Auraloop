using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to check the existence of a cellphone number in the system.
/// </summary>
public class CellphoneExistenceCheckRequestModel
{
    /// <summary>
    /// Gets or sets the cellphone number to check.
    /// </summary>
    [JsonProperty("cellphone")]
    public string Cellphone { get; set; }

    /// <summary>
    /// Gets or sets the country code of the cellphone number.
    /// </summary>
    [JsonProperty("countrycode")]
    public string CountryCode { get; set; } = "86";
}
