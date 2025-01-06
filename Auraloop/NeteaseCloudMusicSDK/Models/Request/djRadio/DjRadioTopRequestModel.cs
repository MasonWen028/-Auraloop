
using Newtonsoft.Json;

public class DjRadioTopRequestModel
{
    [JsonProperty("djRadioId")]
    public string DjRadioId { get; set; }
    [JsonProperty("sortIndex")]
    public int SortIndex { get; set; }
    [JsonProperty("dataGapDays")]
    public int DataGapDays { get; set; }
    [JsonProperty("dataType")]
    public int DataType { get; set; }
}
