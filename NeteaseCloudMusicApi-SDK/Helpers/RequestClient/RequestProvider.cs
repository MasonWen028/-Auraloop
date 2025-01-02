using NeteaseCloudMusicApi_SDK.Helpers.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NeteaseCloudMusicApi_SDK.Helpers.RequestClient
{
    public class RequestProvider
    {
        static Dictionary<string, OSInfo> osMap = new Dictionary<string, OSInfo>
        {
            {
                "pc", new OSInfo
                {
                    OS = "pc",
                    AppVersion = "3.0.18.203152",
                    OSVersion = "Microsoft-Windows-10-Professional-build-22631-64bit",
                    Channel = "netease"
                }
            },
            {
                "linux", new OSInfo
                {
                    OS = "linux",
                    AppVersion = "1.2.1.0428",
                    OSVersion = "Deepin 20.9",
                    Channel = "netease"
                }
            },
            {
                "android", new OSInfo
                {
                    OS = "android",
                    AppVersion = "8.20.20.231215173437",
                    OSVersion = "14",
                    Channel = "xiaomi"
                }
            },
            {
                "iphone", new OSInfo
                {
                    OS = "iPhone OS",
                    AppVersion = "9.0.90",
                    OSVersion = "16.2",
                    Channel = "distribution"
                }
            }
        };

        public string AnonymousToken { get; set; } = "";

        public static string GenerateWNMCID()
        {
            const string characters = "abcdefghijklmnopqrstuvwxyz";
            var random = new Random();
            var randomString = new char[6];

            for (int i = 0; i < 6; i++)
            {
                randomString[i] = characters[random.Next(characters.Length)];
            }

            string timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            return $"{new string(randomString)}.{timestamp}.01.0";
        }

        public static string ChooseUserAgent(string crypto, string uaType = "pc")
        {
            var userAgentMap = new Dictionary<string, Dictionary<string, string>>
        {
            {
                "weapi", new Dictionary<string, string>
                {
                    { "pc", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/124.0.0.0 Safari/537.36 Edg/124.0.0.0" }
                }
            },
            {
                "linuxapi", new Dictionary<string, string>
                {
                    { "linux", "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.90 Safari/537.36" }
                }
            },
            {
                "api", new Dictionary<string, string>
                {
                    { "pc", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Safari/537.36 Chrome/91.0.4472.164 NeteaseMusicDesktop/3.0.18.203152" },
                    { "android", "NeteaseMusic/9.1.65.240927161425(9001065);Dalvik/2.1.0 (Linux; U; Android 14; 23013RK75C Build/UKQ1.230804.001)" },
                    { "iphone", "NeteaseMusic 9.0.90/5038 (iPhone; iOS 16.2; zh_CN)" }
                }
            }
        };

            // Return the User-Agent if found, otherwise return an empty string
            if (userAgentMap.ContainsKey(crypto) && userAgentMap[crypto].ContainsKey(uaType))
            {
                return userAgentMap[crypto][uaType];
            }

            return string.Empty;
        }


        public async Task<HttpResponseMessage> SendRequestAsync(string uri, object data, Options options)
        {
            // Handle cookies
            var cookieDic = HandleCookie(options, uri.Contains("login"));

            // Configure request settings
            var settings = HandleReqSetting(uri, data, options, cookieDic);

            // Configure the HTTP handler with keep-alive
            var handler = new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(5),
                PooledConnectionIdleTimeout = TimeSpan.FromMinutes(2),
                KeepAlivePingPolicy = HttpKeepAlivePingPolicy.WithActiveRequests,
                KeepAlivePingTimeout = TimeSpan.FromSeconds(15)
            };

            using var client = new HttpClient(handler);

            // Create and configure the request
            var request = new HttpRequestMessage
            {
                Method = new HttpMethod(settings.Method),
                RequestUri = new Uri(settings.Url)
            };

            // Add headers
            if (settings.Headers != null)
            {
                foreach (var header in settings.Headers)
                {
                    if (request.Headers.Contains(header.Key))
                    {
                        request.Headers.Remove(header.Key);
                    }
                    request.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Add cookies as a header
            if (cookieDic.Any())
            {
                request.Headers.TryAddWithoutValidation("Cookie", Utils.DictionaryToString(cookieDic));
            }

            // Add body data if present
            if (!string.IsNullOrEmpty(settings.Data))
            {
                request.Content = new StringContent(settings.Data, Encoding.UTF8, "application/x-www-form-urlencoded");
            }

            // Send the request
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // Get the status code
            var statusCode = response.StatusCode;

            // Get the response content as a string
            //var content = await response.Content.ReadAsStringAsync();

            return response;
        }


        public async void SendRequest(string uri, string data, Options options)
        {
            var cookieDic = HandleCookie(options, uri.IndexOf("login") != -1);

            //HandleCrypto(options, data, headers, cookieDic, uri);

            var settings = HandleReqSetting(uri, data, options, cookieDic);

            // Configure the HTTP handler
            var handler = new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(5),
                PooledConnectionIdleTimeout = TimeSpan.FromMinutes(2)
            };

            // Set keep-alive if specified in settings
            if (settings.HttpAgent || settings.HttpsAgent)
            {
                handler.KeepAlivePingPolicy = HttpKeepAlivePingPolicy.WithActiveRequests;
                handler.KeepAlivePingTimeout = TimeSpan.FromSeconds(15);
            }

            using var client = new HttpClient(handler);

            // Create the HttpRequestMessage
            var request = new HttpRequestMessage
            {
                Method = new HttpMethod(settings.Method),
                RequestUri = new Uri(settings.Url),
            };


            if (settings.Headers != null)
            {
                foreach (var header in settings.Headers)
                {
                    if (request.Headers.Contains(header.Key))
                    {
                        request.Headers.Remove(header.Key);
                    }
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            // Add body data
            if (!string.IsNullOrEmpty(settings.Data))
            {
                request.Content = new StringContent(settings.Data, Encoding.UTF8, "application/x-www-form-urlencoded");
            }

            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            string responseData = await response.Content.ReadAsStringAsync();

            var headers = response.Headers;

            Console.WriteLine(response);
        }


        /// <summary>
        /// construct cookie for request
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Dictionary<string, string> HandleCookie(Options options, bool isLogin = false)
        {
            Dictionary<string, string> cookieDic = new Dictionary<string, string>();
            var cookie = options.cookie;
            if (!string.IsNullOrEmpty(cookie))
            {
                cookieDic = Utils.StringToDictionary(cookie);
            }

            var _ntes_nuid = Utils.GenerateRandomString(32);
            OSInfo os = osMap["iphone"];
            if (cookieDic.ContainsKey("os") && !string.IsNullOrEmpty(cookieDic["os"]))
            {
                os = osMap[cookieDic["os"]];
            }

            cookieDic["__remember_me"] = "true";
            cookieDic["ntes_kaola_ad"] = "1";
            cookieDic["_ntes_nuid"] = cookieDic.GetValueOrDefault("_ntes_nuid", Utils.GenerateRandomString(32));
            cookieDic["_ntes_nnid"] = cookieDic.GetValueOrDefault("_ntes_nnid", $"{_ntes_nuid},{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}");
            cookieDic["WNMCID"] = cookieDic.GetValueOrDefault("WNMCID", GenerateWNMCID());
            cookieDic["WEVNSM"] = cookieDic.GetValueOrDefault("WEVNSM", "1.0.0");
            cookieDic["osver"] = cookieDic.GetValueOrDefault("osver", JsonConvert.SerializeObject(os));
            cookieDic["deviceId"] = cookieDic.GetValueOrDefault("deviceId", "defaultDeviceId");
            cookieDic["os"] = cookieDic.GetValueOrDefault("os", JsonConvert.SerializeObject(os));
            cookieDic["channel"] = cookieDic.GetValueOrDefault("channel", "defaultChannel");
            cookieDic["appver"] = cookieDic.GetValueOrDefault("appver", "defaultAppVer");

            if (isLogin)
            {
                cookieDic["NMTID"] = Utils.GenerateRandomString(16);
            }

            if (!cookieDic.ContainsKey("MUSIC_U"))
            {
                cookieDic["MUSIC_A"] = cookieDic.GetValueOrDefault("MUSIC_A", AnonymousToken);
            }

            return cookieDic;
        }


        /// <summary>
        /// construct request header, cookie and data
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="data"></param>
        /// <param name="options"></param>
        /// <param name="cookieDic"></param>
        /// <returns></returns>
        public RequestSetting HandleReqSetting(string uri, object data, Options options, Dictionary<string, string> cookieDic)
        {
            var headers = options.headers ?? new Dictionary<string, string>();
            var ip = options.realIP ?? "";

            if (!string.IsNullOrEmpty(ip))
            {
                headers["X-Real-IP"] = ip;
                headers["X-Forwarded-For"] = ip;
            }

            RequestSetting setting = new RequestSetting();

            string url = "";
            string encryptData = "";
            string csrfToken = cookieDic.GetValueOrDefault("__csrf", "");

            dynamic newData = new ExpandoObject();
            if (data != null)
            {
                newData = data.ToExpandoObject();
            }

            string crypto = options.crypto;
            if (string.IsNullOrEmpty(crypto))
            {
                crypto = Cfg.APP_CONF.Encrypt ? "eapi" : "api";
            }

            switch (crypto)
            {
                case "weapi":
                    headers["Referer"] = Cfg.APP_CONF.Domain;
                    headers["User-Agent"] = !string.IsNullOrEmpty(options.ua) ? options.ua : ChooseUserAgent("weapi");
                    newData.csrf_token = csrfToken;
                    //encryptData = JsonConvert.SerializeObject(CryptoUtils.Weapi(newData));
                    newData = CryptoUtils.Weapi(newData);
                    url = Cfg.APP_CONF.Domain + "/weapi/" + uri.Substring(5);
                    break;
                case "linuxapi":
                    headers["User-Agent"] = options.ua ?? ChooseUserAgent("linuxapi", "linux");
                    newData = new ExpandoObject();
                    newData.method = "POST";
                    newData.url = Cfg.APP_CONF.Domain + uri;
                    newData.@params = data;
                    //encryptData = JsonConvert.SerializeObject(newData);

                    url = Cfg.APP_CONF.Domain + "/api/linux/forward";
                    break;
                case "eapi":
                case "api":

                    var header = new DeviceInfo
                    {
                        OSVersion = cookieDic.GetValueOrDefault("osver"),
                        DeviceId = cookieDic.GetValueOrDefault("deviceId"),
                        OS = cookieDic.GetValueOrDefault("os"),
                        AppVersion = cookieDic.GetValueOrDefault("appver"),
                        VersionCode = cookieDic.GetValueOrDefault("versioncode", "140"),
                        MobileName = cookieDic.GetValueOrDefault("mobilename", string.Empty),
                        BuildVersion = cookieDic.GetValueOrDefault("buildver", DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
                        Resolution = cookieDic.GetValueOrDefault("resolution", "1920x1080"),
                        CSRF = csrfToken,
                        Channel = cookieDic.GetValueOrDefault("channel"),
                        RequestId = $"{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}_{new Random().Next(0, 10000).ToString("D4")}"
                    };

                    if (cookieDic.ContainsKey("MUSIC_U"))
                    {
                        header.MUSIC_U = cookieDic.GetValueOrDefault("MUSIC_U");
                    }

                    if (cookieDic.ContainsKey("MUSIC_A"))
                    {
                        header.MUSIC_U = cookieDic.GetValueOrDefault("MUSIC_A");
                    }

                    headers["Cookie"] = header.ToEncodedHeaderString();

                    headers["UserAgent"] = string.IsNullOrEmpty(options.ua) ? options.ua : ChooseUserAgent("api", "iphone");

                    if (crypto == "eapi")
                    {
                        if (!string.IsNullOrEmpty(options.e_r))
                        {
                            newData.E_R = options.e_r;
                        }
                        else if (Cfg.APP_CONF.EncryptResponse)
                        {
                            newData.E_R = Cfg.APP_CONF.EncryptResponse;
                        }

                        //encryptData = JsonConvert.SerializeObject(CryptoUtils.Eapi(uri, newData));

                        newData = CryptoUtils.Eapi(uri, newData);
                        url = Cfg.APP_CONF.Domain + "/eapi/" + uri.Substring(5);
                    }
                    else
                    {
                        url = Cfg.APP_CONF.Domain + uri;
                        //encryptData = JsonConvert.SerializeObject(newData);
                    }

                    break;
                default:

                    break;
            }

            setting.Method = "Post";
            setting.Url = url;
            setting.Headers = headers;
            setting.Data = Utils.ConvertToQueryString(newData);


            //TODO when data.e_r is not null or true
            // Submit encoding and responseType with the request
            //if (options.e_r)
            //{

            //}

            return setting;
        }


        public static ExpandoObject HandleCrypto(Options options, object data, Dictionary<string, string> headers, Dictionary<string, string> cookie, string uri)
        {
            dynamic setting = new ExpandoObject();
            string url = "";
            string encryptData = "";
            dynamic newData = (ExpandoObject)data;

            string csrfToken = cookie.ContainsKey("__csrf") ? cookie["__csrf"] : string.Empty;

            string crypto = options.crypto;
            if (string.IsNullOrEmpty(crypto))
            {
                if (Cfg.APP_CONF.Encrypt)
                {
                    crypto = "eapi";
                }
                else
                {
                    crypto = "api";
                }
            }

            switch (crypto)
            {
                case "weapi":
                    headers["Referer"] = Cfg.APP_CONF.Domain;
                    headers["User-Agent"] = options.ua ?? ChooseUserAgent("weapi");
                    newData.csrf_token = csrfToken;
                    encryptData = JsonConvert.SerializeObject(CryptoUtils.Weapi(newData));
                    url = Cfg.APP_CONF.Domain + "/weapi/" + uri.Substring(5);
                    break;
                case "linuxapi":
                    headers["User-Agent"] = options.ua ?? ChooseUserAgent("linuxapi", "linux");
                    newData = new ExpandoObject();
                    newData.method = "POST";
                    newData.url = Cfg.APP_CONF.Domain + uri;
                    newData.@params = data;
                    encryptData = JsonConvert.SerializeObject(newData);

                    url = Cfg.APP_CONF.Domain + "/api/linux/forward";
                    break;
                case "eapi":
                case "api":


                    break;
                default:

                    break;
            }

            setting.method = "POST";
            setting.url = url;
            setting.headers = headers;
            setting.data = Utils.ConvertToQueryString(encryptData);


            return setting;
        }

        public static HttpClient CreateHttpClientWithKeepAlive()
        {
            var handler = new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(5), // Reuse connections for 5 minutes
                PooledConnectionIdleTimeout = TimeSpan.FromMinutes(2), // Keep idle connections alive for 2 minutes
                MaxConnectionsPerServer = 10, // Limit the maximum number of connections per server
                KeepAlivePingPolicy = HttpKeepAlivePingPolicy.WithActiveRequests,
                KeepAlivePingTimeout = TimeSpan.FromSeconds(15) // Send a ping every 15 seconds for active connections
            };

            return new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(30) // Set request timeout
            };
        }




        public static Dictionary<string, string> CookieToJson(string cookieString)
        {
            // Convert the cookie string to a dictionary (implement parsing logic)
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(cookieString);
        }

        public static string CookieObjToString(Dictionary<string, string> cookieDict)
        {
            // Convert the cookie dictionary to a cookie string
            var cookies = new List<string>();
            foreach (var kvp in cookieDict)
            {
                cookies.Add($"{kvp.Key}={kvp.Value}");
            }
            return string.Join("; ", cookies);
        }




    }
}
