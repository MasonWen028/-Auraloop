using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Helpers.RequestClient
{
    public class AppConf
    {
        public string ApiDomain { get; set; }
        public string Domain { get; set; }
        public bool Encrypt { get; set; }
        public bool EncryptResponse { get; set; }
    }
    public static class Cfg
    {
        public static Dictionary<string, string> ResourceTypeMap = new Dictionary<string, string>
            {
                { "0", "R_SO_4_" },
                { "1", "R_MV_5_" },
                { "2", "A_PL_0_" },
                { "3", "R_AL_3_" },
                { "4", "A_DJ_1_" },
                { "5", "R_VI_62_" },
                { "6", "A_EV_2_" },
                { "7", "A_DR_14_" }
            };

        public static AppConf APP_CONF = new AppConf
        {
            ApiDomain = "https://interface.music.163.com",
            Domain = "https://music.163.com",
            Encrypt = true,
            EncryptResponse = false
        };
    }

}
