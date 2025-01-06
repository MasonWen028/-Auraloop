
using Newtonsoft.Json;

public class YunbeiTaskFinishRequestModel
{
    [JsonProperty("userTaskId")]
    public string UserTaskId { get; set; }
    [JsonProperty("depositCode")]
    public string DepositCode { get; set; }
}
