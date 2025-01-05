using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeteaseCloudMusicSDK.RequestClient.Models
{
    /// <summary>
    /// Represents device-specific metadata and request headers to be sent to the server.
    /// </summary>
    /// <remarks>
    /// This model is used primarily in `eapi` and `api` requests to provide information about the device,
    /// application, and user. It encapsulates key details such as operating system, application version,
    /// device ID, and headers like User-Agent and CSRF tokens.
    ///
    /// The properties are designed to align with typical remote endpoint requirements, ensuring proper 
    /// authentication, debugging, and request tracking.
    ///
    /// **Purpose**:
    /// - Provides device and application details to the remote server.
    /// - Supplies headers like CSRF tokens, User-Agent, and custom cookies for authentication.
    /// - Generates unique request identifiers for tracking.
    ///
    /// **Usage**:
    /// This model should be serialized into the appropriate request headers or payload for API calls.
    /// Example use cases include mobile app requests, web service calls, or secure API interactions.
    ///
    /// **Notes**:
    /// - Defaults are provided for certain fields like `VersionCode`, `BuildVersion`, `Resolution`, and `RequestId`.
    /// - Randomized and timestamp-based values ensure uniqueness for `BuildVersion` and `RequestId`.
    /// - Fields like `MUSIC_U` and `MUSIC_A` are application-specific tokens that may vary based on user context.
    /// </remarks>
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
