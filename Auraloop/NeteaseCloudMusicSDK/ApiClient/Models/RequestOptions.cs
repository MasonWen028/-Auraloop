


namespace NeteaseCloudMusicSDK.ApiClient.Models
{
    /// <summary>
    /// Represents options for making a request, including request data, URI, encryption settings, and additional headers.
    /// </summary>
    public class RequestOptions
    {
        /// <summary>
        /// The data model representing the payload of the request.
        /// </summary>
        public object RequestModel { get; set; }

        /// <summary>
        /// The URI endpoint to which the request is sent.
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// The encryption method used for the request. Defaults to "eapi".
        /// </summary>
        public string Crypto { get; set; } = "eapi";

        /// <summary>
        /// The cookie string to be included in the request headers. Defaults to an empty string.
        /// </summary>
        public string Cookie { get; set; } = string.Empty;

        /// <summary>
        /// The real IP address to be included in the request headers. Defaults to an empty string.
        /// </summary>
        public string RealIp { get; set; } = string.Empty;

        /// <summary>
        /// The User-Agent string to be included in the request headers. Defaults to an empty string.
        /// </summary>
        public string UserAgent { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestOptions"/> class with optional parameters.
        /// </summary>
        /// <param name="requestModel">The data model representing the payload of the request.</param>
        /// <param name="uri">The URI endpoint to which the request is sent.</param>
        /// <param name="crypto">The encryption method used for the request. Defaults to "eapi".</param>
        /// <param name="cookie">The cookie string to be included in the request headers. Defaults to an empty string.</param>
        /// <param name="realIp">The real IP address to be included in the request headers. Defaults to an empty string.</param>
        /// <param name="userAgent">The User-Agent string to be included in the request headers. Defaults to an empty string.</param>
        public RequestOptions(
            string uri,
            object requestModel = null,            
            string crypto = "eapi",
            string cookie = "",
            string realIp = "",
            string userAgent = "")
        {
            Uri = uri;
            RequestModel = requestModel;            
            Crypto = crypto;
            Cookie = cookie;
            RealIp = realIp;
            UserAgent = userAgent;
        }
    }

}