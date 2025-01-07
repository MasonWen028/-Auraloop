using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeteaseCloudMusicSDK.Models.Request.yunbei
{
    public class YunbeiRecommendedSongsRequestModel
    {
        [JsonProperty("songId")]
        public string SongId { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("scene")]
        public string Scene { get; set; } = "";

        [JsonProperty("fromUserId")]
        public int FromUserId { get; set; } = -1;

        [JsonProperty("yunbeiNum")]
        public int YunbeiNum { get; set; } = 10;
    }
}
