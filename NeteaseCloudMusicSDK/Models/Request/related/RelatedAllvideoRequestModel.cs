
using Newtonsoft.Json;
using System.Text.RegularExpressions;

public class RelatedAllvideoRequestModel
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("type")]
    public int Type { get; set; }

    public RelatedAllvideoRequestModel(string queryId)
    {
        // Assign the Id
        Id = queryId;

        // Regex: ^\d+$ means "entire string is digits"
        bool isNumeric = Regex.IsMatch(queryId, @"^\d+$");

        // If numeric ¡ú type = 0; otherwise ¡ú type = 1
        Type = isNumeric ? 0 : 1;
    }
}
