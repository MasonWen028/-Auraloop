namespace NeteaseCloudMusicApi_SDK.Services
{
    public class OptionService
    {
        /// <summary>
        /// Creates headers for the outgoing HTTP request.
        /// </summary>
        /// <param name="options">Request options containing information like cookies, User-Agent, etc.</param>
        /// <returns>A dictionary of headers for the HTTP request.</returns>
        public Dictionary<string, string> CreateHeaders(RequestOptions options)
        {
            var headers = options.Headers ?? new Dictionary<string, string>();

            // Add real IP address if provided
            if (!string.IsNullOrEmpty(options.RealIP))
            {
                headers["X-Real-IP"] = options.RealIP;
                headers["X-Forwarded-For"] = options.RealIP;
            }

            // Add cookie if provided
            if (!string.IsNullOrEmpty(options.Cookie))
            {
                headers["Cookie"] = options.Cookie;
            }

            // Set the User-Agent, defaulting to a generic browser if not provided
            headers["User-Agent"] = options.Ua ?? "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36";

            return headers;
        }


        /// <summary>
        /// Converts a string value to a boolean.
        /// </summary>
        /// <param name="value">The input string.</param>
        /// <returns>A boolean representation of the value.</returns>
        private bool ToBoolean(string value)
        {
            return value == "true" || value == "1";
        }
    }

    /// <summary>
    /// Represents the options for an API request.
    /// </summary>
    public class RequestOptions
    {
        public string Method { get; set; } = "GET";
        public string Crypto { get; set; } = "weapi";
        public string Cookie { get; set; }
        public string RealIP { get; set; }
        public string Proxy { get; set; }

        public bool? EncryptResponse { get; set; }
        public string Ua { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public string Uri { get; set; }
    }

}
