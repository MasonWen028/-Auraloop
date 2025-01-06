using System;
using System.Collections.Generic;
using System.Text;

namespace NeteaseCloudMusicSDK.NetEaseApiClient.Models
{
    public class RequestOptions
    {
        public object RequestModel { get; set; }
        public string Uri { get; set; }
        public string Crypto { get; set; } = "eapi";
        public string Cookie { get; set; } = string.Empty; // Default value
        public string RealIp { get; set; } = string.Empty; // Default value
        public string UserAgent { get; set; } = string.Empty; // Default value
    }

}
