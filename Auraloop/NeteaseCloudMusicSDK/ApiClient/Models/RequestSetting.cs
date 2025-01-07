using Newtonsoft.Json;

using System.Collections.Generic;


namespace NeteaseCloudMusicSDK.ApiClient.Models
{
    /// <summary>
    /// Represents the configuration and settings for an HTTP request.
    /// </summary>
    /// <remarks>
    /// This class is used to define the HTTP method, URL, headers, body data, and agent options for submitting a request. 
    /// It standardizes the structure of a request configuration to simplify and unify HTTP operations in the application.
    /// </remarks>
    public class RequestSetting
    {
        /// <summary>
        /// The HTTP method to use (e.g., "POST", "GET"). Defaults to "POST".
        /// </summary>
        [JsonProperty("method")]
        public string Method { get; set; } = "POST";

        /// <summary>
        /// The request URL.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// The request headers.
        /// </summary>
        [JsonProperty("headers")]
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// content ready for submit
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; set; }

        /// <summary>
        /// Indicates whether to use an HTTP agent. Defaults to false.
        /// </summary>
        [JsonProperty("httpAgent")]
        public bool HttpAgent { get; set; } = false;

        /// <summary>
        /// Indicates whether to use an HTTPS agent. Defaults to false.
        /// </summary>
        [JsonProperty("httpsAgent")]
        public bool HttpsAgent { get; set; } = false;
    }
}