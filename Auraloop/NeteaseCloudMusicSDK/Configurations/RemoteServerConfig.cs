using System;
using System.Collections.Generic;
using System.Text;

namespace NeteaseCloudMusicSDK.Configurations
{
    public class RemoteServerConfig
    {
        public string ApiDomain { get; } = "https://interface.music.163.com";
        public string Domain { get; } = "https://music.163.com";
        public bool Encrypt { get; } = true;
        public bool EncryptResponse { get; } = false;

        public Dictionary<string, string> ResourceTypeMap = new Dictionary<string, string>
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

        private RemoteServerConfig() { }

        public static RemoteServerConfig Instance { get; } = new RemoteServerConfig();
    }

}
