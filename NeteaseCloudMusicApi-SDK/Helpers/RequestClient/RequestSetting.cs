using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Helpers.RequestClient
{
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

    public class RequestSettingEr : RequestSetting
    {
        /// <summary>
        /// The response type (e.g., "json", "text").
        /// </summary>
        [JsonProperty("responseType")]
        public string ResponseType { get; set; }

        /// <summary>
        /// The encoding used in the request or response.
        /// </summary>
        [JsonProperty("encoding")]
        public object Encoding { get; set; }
    }

    public class DeviceInfo
    {
        /// <summary>
        /// The operating system version (e.g., "Windows 10", "iOS 16.2").
        /// </summary>
        [JsonProperty("osver")]
        public string OSVersion { get; set; }

        /// <summary>
        /// The unique identifier of the device.
        /// </summary>
        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }

        /// <summary>
        /// The operating system type (e.g., "pc", "ios", "android").
        /// </summary>
        [JsonProperty("os")]
        public string OS { get; set; }

        /// <summary>
        /// The version of the application.
        /// </summary>
        [JsonProperty("appver")]
        public string AppVersion { get; set; }

        /// <summary>
        /// The version code of the application. Defaults to "140".
        /// </summary>
        [JsonProperty("versioncode")]
        public string VersionCode { get; set; } = "140";

        /// <summary>
        /// The name of the mobile device model (e.g., "iPhone 13", "Galaxy S21").
        /// Defaults to an empty string.
        /// </summary>
        [JsonProperty("mobilename")]
        public string MobileName { get; set; } = string.Empty;

        /// <summary>
        /// The build version, represented as a timestamp in seconds. Defaults to the current timestamp.
        /// </summary>
        [JsonProperty("buildver")]
        public string BuildVersion { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();

        /// <summary>
        /// The screen resolution of the device (e.g., "1920x1080"). Defaults to "1920x1080".
        /// </summary>
        [JsonProperty("resolution")]
        public string Resolution { get; set; } = "1920x1080";

        /// <summary>
        /// The CSRF token for authentication.
        /// </summary>
        [JsonProperty("__csrf")]
        public string CSRF { get; set; }

        /// <summary>
        /// The download channel for the application (e.g., "official", "xiaomi").
        /// </summary>
        [JsonProperty("channel")]
        public string Channel { get; set; }

        /// <summary>
        /// The unique request ID, combining the current timestamp and a random 4-digit number.
        /// </summary>
        [JsonProperty("requestId")]
        public string RequestId { get; set; } = $"{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}_{new Random().Next(0, 10000).ToString("D4")}";

        public string MUSIC_U { get; set; }

        public string MUSIC_A { get; set; }

        public string Cookie { get; set; }

        [JsonProperty("User-Agent")]
        public string UserAgent { get; set; }
    }

}
