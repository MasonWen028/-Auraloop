
using Newtonsoft.Json;

public class CloudRequestModel
{
// No data fields found
}


/// <summary>
/// get temporary token before uploading mp3 file
/// </summary>
public class TokenallocRequestModel
{
    /// <summary>
    /// which bucket it would use to save this mp3
    /// </summary>
    [JsonProperty("bucket")]
    public string Bucket { get; set; } = "jd-musicrep-privatecloud-audio-public";

    /// <summary>
    /// extension name of this file, it should always be mp3
    /// </summary>
    [JsonProperty("ext")]
    public string Ext { get; set; } = "mp3";


    /// <summary>
    /// the name of uploading file with out extension name
    /// </summary>
    [JsonProperty("filename")]
    public string FileName { get; set; }

    /// <summary>
    /// whether the file is local or not, it should always be false
    /// </summary>
    [JsonProperty("local")]
    public bool Local { get; set; } = false;

    /// <summary>
    /// always be 3
    /// </summary>
    [JsonProperty("nos_product")]
    public int NosProduct { get; set; } = 3;

    /// <summary>
    /// the type of uploading file, it should always be "audio"
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; } = "audio";

    /// <summary>
    /// the md5 fo uploading file
    /// </summary>
    [JsonProperty("md5")]
    public string Md5 { get; set; }
}

/// <summary>
/// Request token before uploading action response
/// </summary>
public class TokenResponse
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("code")]
    public int Code { get; set; }
    /// <summary>
    /// the msg from the server, if something is wrong
    /// </summary>
    [JsonProperty("message")]
    public string Message { get; set; }

    /// <summary>
    /// the token, objectKey, resourceId
    /// </summary>
    [JsonProperty("result")]
    public TokenResult Result { get; set; }
}

/// <summary>
/// token content
/// </summary>
public class TokenResult
{
    /// <summary>
    /// the bucket we want to upload our file
    /// </summary>
    public string Bucket { get; set; }
    /// <summary>
    /// token 
    /// </summary>
    public string Token { get; set; }
    /// <summary>
    /// the link url could be accessed from outer page / interface
    /// </summary>
    public string OuterUrl { get; set; }

    /// <summary>
    /// doc id
    /// </summary>
    public string DocId { get; set; }
    /// <summary>
    /// Uploading action key parameter
    /// </summary>
    public string ObjectKey { get; set; }

    /// <summary>
    /// the pre-assinged resource id
    /// </summary>
    public long ResourceId { get; set; }
}



/// <summary>
/// check the md5 and file info before uploading
/// </summary>
public class UploadCheckRequestModel
{
    /// <summary>
    /// bitrate for uploading file
    /// </summary>
    [JsonProperty("bitrate")]
    public string Bitrate { get; set; } = "999000";

    /// <summary>
    /// extension name of this file, it should always be mp3
    /// </summary>
    [JsonProperty("ext")]
    public string Ext { get; set; } = "mp3";

    /// <summary>
    /// length of the uploading file
    /// </summary>
    [JsonProperty("length")]
    public long Length { get; set; }

    /// <summary>
    /// the md5 fo uploading file
    /// </summary>
    [JsonProperty("md5")]
    public string Md5 { get; set; }

    [JsonProperty("songId")]
    public string SongId { get; set; } = "0";

    [JsonProperty("version")]
    public int Version { get; set; } = 1;

}

/// <summary>
/// the response model for Upload Check interface
/// </summary>
public class CheckResponse
{
    /// <summary>
    /// if the song already existed, this id would be a string.
    /// </summary>
    [JsonProperty("songId")]
    public string SongId { get; set; }
    /// <summary>
    /// the file trying to upload existed or not.
    /// </summary>
    [JsonProperty("needUpload")]
    public bool NeedUpload { get; set; }
    /// <summary>
    /// status code for this interface, 200 stands successful request.
    /// </summary>
    [JsonProperty("code")]
    public int Code { get; set; }
}

public class LbsResponse
{
    /// <summary>
    /// The Load Balancer Service (LBS) URL.
    /// </summary>
    public string Lbs { get; set; }

    /// <summary>
    /// List of upload URLs.
    /// </summary>
    public List<string> Upload { get; set; }
}

