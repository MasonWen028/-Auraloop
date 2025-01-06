
using Newtonsoft.Json;
using System.Collections.Generic;

public class AidjContentRcmdRequestModel
{
    [JsonProperty("extInfo")]
    public string ExtInfo { get; set; }
}

public class ExtInfo
{
    [JsonProperty("lbsInfoList")]
    public  List<LbsInfo>LlbsInfoList { get; set; }

    [JsonProperty("noAidjToAidj")]
    public bool NoAidjToAidj { get; set; }

    [JsonProperty("lastRequestTimestamp")]
    public long lastRequestTimestamp { get; set; }

    [JsonProperty("listenedTs")]
    public bool listenedTs { get; set; }
}


public class LbsInfo
{
    [JsonProperty("lat")]
    public double Lat { get; set; }

    [JsonProperty("lon")]
    public double Lon { get; set; }

    /// <summary>
    /// 10 digits time stamp
    /// </summary>
    [JsonProperty("time")]
    public long Time { get; set; }
}
