


namespace NeteaseCloudMusicSDK.ApiClient.Models
{
    /// <summary>
    /// Model for storaging the OS info
    /// </summary>
    public class OSInfo
    {
        /// <summary>
        /// Operating system type (e.g., pc, linux, android, iPhone OS).
        /// </summary>
        public string OS { get; set; }

        /// <summary>
        /// Application version.
        /// </summary>
        public string AppVersion { get; set; }

        /// <summary>
        /// Operating system version or build details.
        /// </summary>
        public string OSVersion { get; set; }

        /// <summary>
        /// Distribution channel (e.g., netease, xiaomi, distribution).
        /// </summary>
        public string Channel { get; set; }
    }
}
