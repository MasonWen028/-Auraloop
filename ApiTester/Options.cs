using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTester
{
    public class Options
    {
        public string crypto { get; set; }
        public string cookie { get; set; }
        public string ua { get; set; }
        public string proxy { get; set; }
        public string realIP { get; set; }
        public string e_r { get; set; }

        public Dictionary<string, string> headers { get; set; }

        /// <summary>
        /// create options by query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="crypto"></param>
        public Options(Dictionary<string, string> query, string crypto = "") 
        {
            string tempCrypto = GetValue(query, "crypto");
            this.crypto = tempCrypto ?? crypto;
            this.cookie = GetValue(query, "cookie");
            this.ua = GetValue(query, "ua");
            this.proxy = GetValue(query, "proxy");
            this.realIP = GetValue(query, "realIP");
            this.e_r = GetValue(query, "e_r");
        }

        /// <summary>
        /// get value by key from a dictionary
        /// </summary>
        /// <param name="query"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private string GetValue(Dictionary<string, string> query, string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return string.Empty;
            }

            if (query == null || query.Count == 0)
            {
                return string.Empty;
            }
            if (query.ContainsKey(key))
            {
                return query[key];
            }

            return string.Empty;
        }
    }

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
