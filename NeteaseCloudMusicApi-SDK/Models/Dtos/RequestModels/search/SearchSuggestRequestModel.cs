
using Newtonsoft.Json;

public class SearchSuggestRequestModel
{
    [JsonProperty("s")]
    public string S { get; set; }
}
