
using Newtonsoft.Json;

public class CellphoneExistenceCheckRequestModel
{
    [JsonProperty("cellphone")]
    public string Cellphone { get; set; }
    [JsonProperty("countrycode")]
    public int Countrycode { get; set; }
}
