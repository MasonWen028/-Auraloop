using NeteaseCloudMusicSDK.NetEaseApiClient.Models;
using System.ComponentModel.Design;
using System.Net;

namespace SDKTestor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Create and configure HttpClient
            var handler = new HttpClientHandler
            {
                AllowAutoRedirect = true,
                MaxConnectionsPerServer = 10
            };

            using var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://music.163.com"), // Set base URL for the API
                Timeout = TimeSpan.FromSeconds(100)
            };

            // Step 2: Inject HttpClient into NetEaseApiClient
            var netEaseApiClient = new NetEaseApiClient(httpClient);

            string uri = "/api/album/new";

            var data = new {
              limit = 500,
              offset = 0,
              total = true,
              area = "ALL"
            };

            string u1 = "/api/v1/comment/like";

            var d = new
            {
                threadId = "R_SO_4_2039323889",
                commentId = 2039323889
            };


            //          "resourceTypeMap": {
            //              "0": "R_SO_4_",
            //  "1": "R_MV_5_",
            //  "2": "A_PL_0_",
            //  "3": "R_AL_3_",
            //  "4": "A_DJ_1_",
            //  "5": "R_VI_62_",
            //  "6": "A_EV_2_",
            //  "7": "A_DR_14_"
            //},

            RequestOptions options = new RequestOptions
            {
                Uri = u1,
                RequestModel = d,
                Cookie = "MUSIC_U=005F14D98085815617A46F437C40963858A89F21C6298AF32C5C2A19A880D6C6AF932D7E4D81158F2A9622830AE0EFAF0BB2C0D9265C0CD6EB6EA8474DC4C824C0E6EB5D338F4C5AB00478AA679972652185CAE8BEF0F75AB68A658854AEB8A1FAFCB1DDE95D9D19DC815524F401E3530B699E55538131CB4AEF07F5EA2F045BB0AA4DB7133558C97E5EE374FEDF8BBFCF1B84AE0A075C6CCB5D1BF3F89F713C14ED01CD2F95172AF95D40437B8DBB871B76C0A6973D307D503D16E7C8348D9A023F705599BD1817E766EE19E1F8B79085E3E1C82D4C8FE5FF8EA2E11497FCE57A79EBD058827A1118EB2A2F0F742070D6A69217CD3A4B7A9A56E9AF0CBEFA4E1E57DD45F5AA7D43E349FA333ACBC91B81FF224AC6D322F28BD1CDBAB65C3D17770E488BA70E970E35F82F066DFA79635490EA3F89AEC9502342644FD4AA317371E4F679270826D82F631CB71A25E1D57DA33EE897395C6F1724F13514D9928A3E; __csrf=79a62388899b286e3d57511174527b9b;"
            };

            try
            {
                var result = netEaseApiClient.HandleRequestAsync(options).Result;
                Console.WriteLine("API Response:");
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}
