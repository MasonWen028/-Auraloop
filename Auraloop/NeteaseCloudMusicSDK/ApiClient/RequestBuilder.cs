using NeteaseCloudMusicSDK.Configurations;
using NeteaseCloudMusicSDK.Extensions;
using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;


/// <summary>
/// A utility class for building and preparing HTTP requests.
/// </summary>
/// <remarks>
/// The <see cref="RequestBuilder"/> class provides methods for constructing 
/// various types of HTTP requests (e.g., GET, POST) with headers, query 
/// parameters, and request bodies.
/// 
/// This class is designed to simplify the process of creating consistent and 
/// reusable HTTP requests for API communication, ensuring proper formatting 
/// and avoiding repetitive code in services.
/// </remarks>
public class RequestBuilder
{
    private Dictionary<string, string> currentCookies = new Dictionary<string, string>();

    public Dictionary<string, string> CurrentCookies
    {
        get
        {
            return currentCookies;
        }
        set
        {
            currentCookies = value;
        }
    }

    private RequestSetting setting;

    public RequestSetting Setting
    {
        get { return setting; }
        set { setting = value; }
    }

    /// <summary>
    /// Create request for sending
    /// </summary>
    /// <param name="option"></param>
    public RequestBuilder(RequestOptions option)
    {
        object requestModel = option.RequestModel;
        string uri = option.Uri;
        string crypto = option.Crypto;
        string cookie = option.Cookie;
        string realIp = option.RealIp;
        string ua = option.UserAgent;

        setting = PrepareRequest(uri, requestModel, crypto, cookie, realIp, ua);
    }
    /// <summary>
    /// load the default configuration
    /// </summary>
    static RemoteServerConfig cfg = RemoteServerConfig.Instance;
    /// <summary>
    /// OS information for diefferent OS type.
    /// </summary>
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
    /// <summary>
    /// Generate random
    /// </summary>
    /// <returns></returns>
    private string GenerateWNMCID()
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

    /// <summary>
    /// Select UserAgent by crypto type
    /// </summary>
    /// <param name="crypto">crypto type</param>
    /// <param name="uaType">useragent type</param>
    /// <returns></returns>
    private string ChooseUserAgent(string crypto, string uaType = "pc")
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
        if (userAgentMap.ContainsKey(crypto) && userAgentMap[crypto].ContainsKey(uaType))
        {
            return userAgentMap[crypto][uaType];
        }

        return string.Empty;
    }

    /// <summary>
    /// Prepares and standardizes a dictionary of cookies based on the original cookie string and additional parameters.
    /// </summary>
    /// <param name="oriCookie">
    /// The original cookie string, which is parsed into a dictionary. If null or empty, an empty dictionary is initialized.
    /// </param>
    /// <param name="isLogin">
    /// Indicates whether the cookie is being prepared for a login request. If true, additional login-related keys are added.
    /// </param>
    /// <returns>
    /// A dictionary of cookies with standardized and default values. Missing keys are populated with default or generated values.
    /// </returns>
    /// <remarks>
    /// This method processes the given cookie string and ensures that certain required cookie keys are present with valid values.
    /// If a key is missing, it is assigned a default value or a dynamically generated one. 
    ///
    /// Key Behaviors:
    /// - Parses the `oriCookie` string into a dictionary.
    /// - Adds or updates specific keys, such as `__remember_me`, `_ntes_nuid`, `_ntes_nnid`, and others.
    /// - Supports additional logic for login-related cookies if `isLogin` is true.
    /// - Handles anonymous requests by ensuring `MUSIC_A` is prepared when `MUSIC_U` is not present (TODO section).
    ///
    /// Keys and Their Defaults:
    /// - `_ntes_nuid`: A random 32-character string.
    /// - `_ntes_nnid`: A combination of `_ntes_nuid` and the current UTC timestamp.
    /// - `WNMCID`: A generated unique value.
    /// - `osver`: Serialized OS information (default: "iphone").
    /// - `deviceId`, `channel`, `appver`: Assigned default strings.
    /// - `NMTID` (only if `isLogin` is true): A random 16-character string.
    /// </remarks>
    /// <example>
    /// Example usage:
    /// <code>
    /// var cookies = PrepareCookie("os=android; WNMCID=abc123", isLogin: true);
    /// // Resulting dictionary:
    /// // {
    /// //     "__remember_me": "true",
    /// //     "ntes_kaola_ad": "1",
    /// //     "_ntes_nuid": "random_generated_string",
    /// //     "_ntes_nnid": "random_generated_string,timestamp",
    /// //     "WNMCID": "abc123",
    /// //     "WEVNSM": "1.0.0",
    /// //     "osver": "serialized_os_info",
    /// //     "deviceId": "defaultDeviceId",
    /// //     "os": "serialized_os_info",
    /// //     "channel": "defaultChannel",
    /// //     "appver": "defaultAppVer",
    /// //     "NMTID": "random_generated_string" // Only if isLogin is true
    /// // }
    /// </code>
    /// </example>
    private Dictionary<string, string> PrepareCookie(string oriCookie, bool isLogin = false)
    {
        Dictionary<string, string> cookieDic = new Dictionary<string, string>();
        if (!string.IsNullOrEmpty(oriCookie))
        {
            cookieDic = DicStrUtil.StringToDictionary(oriCookie);
        }

        var _ntes_nuid = RandomStringUtil.GenerateRandomString(32);
        OSInfo os = osMap["iphone"];
        if (cookieDic.ContainsKey("os") && !string.IsNullOrEmpty(cookieDic["os"]))
        {
            os = osMap[cookieDic["os"]];
        }

        cookieDic["__remember_me"] = "true";
        cookieDic["ntes_kaola_ad"] = "1";
        cookieDic["_ntes_nuid"] = cookieDic.GetValueOrDefault("_ntes_nuid", RandomStringUtil.GenerateRandomString(32));
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
            cookieDic["NMTID"] = RandomStringUtil.GenerateRandomString(16);
        }

        if (!cookieDic.ContainsKey("MUSIC_U"))
        {
            //TODO if it's an anonymous request, get music_a value, if has no value, call /api/register/anonimous to get anonymous token.
            //cookieDic["MUSIC_A"] = cookieDic.GetValueOrDefault("MUSIC_A", AnonymousToken);
        }

        currentCookies = cookieDic;

        return cookieDic;
    }


    /// <summary>
    /// Prepares and populates the headers dictionary with standard and optional values.
    /// </summary>
    /// <param name="cookieDic">
    /// A dictionary of cookies (not currently used in this method but may be extended in the future).
    /// </param>
    /// <param name="realIp">
    /// The real IP address to include in the headers for tracking or logging purposes. 
    /// If specified, it is added as both "X-Real-IP" and "X-Forwarded-For".
    /// </param>
    /// <param name="ua">
    /// The User-Agent string to specify the client making the request. 
    /// If null or empty, a default User-Agent is chosen.
    /// </param>
    /// <remarks>
    /// This method ensures that critical headers, such as "X-Real-IP", "X-Forwarded-For", and "User-Agent",
    /// are present in the headers dictionary. If "realIp" is provided, it sets the appropriate tracking headers.
    /// If "ua" is not provided, a default User-Agent is selected using <see cref="ChooseUserAgent(string)"/>.
    /// </remarks>
    /// <example>
    /// Example usage:
    /// <code>
    /// var headers = new Dictionary<string, string>();
    /// PrepareHeaders(headers, cookieDic, "192.168.1.1", "Custom-User-Agent");
    /// // headers now contains:
    /// // {
    /// //     { "X-Real-IP", "192.168.1.1" },
    /// //     { "X-Forwarded-For", "192.168.1.1" },
    /// //     { "User-Agent", "Custom-User-Agent" }
    /// // }
    /// </code>
    /// </example>
    private Dictionary<string, string> PrepareHeaders(Dictionary<string, string> cookieDic, string crypto, string realIp = "", string ua = "")
    {
        var headers = new Dictionary<string, string>();

        string csrfToken = cookieDic.GetValueOrDefault("__csrf", "");

        if (!string.IsNullOrEmpty(realIp))
        {
            headers["X-Real-IP"] = realIp;
            headers["X-Forwarded-For"] = realIp;
        }

        headers["User-Agent"] = !string.IsNullOrEmpty(ua) ? ua : ChooseUserAgent(crypto);

        if (crypto == "eapi" || crypto == "api")
        {
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
        }
        else
        {
            headers["Cookie"] = cookieDic.DictionaryToString();
        }

        return headers;
    }

    /// <summary>
    /// Prepares a complete request setting, including headers, data, and URL, for making an API request.
    /// </summary>
    /// <param name="uri">The endpoint URI to which the request will be sent.</param>
    /// <param name="data">The request data to be processed.</param>
    /// <param name="crypto">
    /// The encryption method to use ("weapi", "linuxapi", "eapi", or "api"). Determines how the data and URL are prepared.
    /// </param>
    /// <param name="cookieDic">
    /// A dictionary of cookies used to retrieve the CSRF token and other necessary data for the request.
    /// </param>
    /// <param name="realIp">
    /// The real IP address to include in the headers for tracking or forwarding purposes. Optional.
    /// </param>
    /// <param name="ua">
    /// The User-Agent string to include in the headers. If not specified, a default User-Agent is used.
    /// </param>
    /// <returns>
    /// A <see cref="RequestSetting"/> object containing the HTTP method, URL, headers, and data for the API request.
    /// </returns>
    /// <remarks>
    /// This method performs the following steps:
    /// 1. Prepares the headers using the specified cookies, encryption type, IP address, and User-Agent.
    /// 2. Processes the data object and constructs the URL based on the `crypto` method.
    /// 3. Combines the prepared headers, URL, and data into a `RequestSetting` object for submission.
    ///
    /// **Notes**:
    /// - The method uses "POST" as the default HTTP method.
    /// - Data is converted into a query string format before being included in the `RequestSetting`.
    /// - Supports encryption methods like `weapi`, `linuxapi`, and `eapi` based on the `crypto` parameter.
    /// </remarks>
    public RequestSetting PrepareRequest(string uri, object data, string crypto, string cookie, string realIp, string ua)
    {
        Dictionary<string, string> cookieDic = PrepareCookie(cookie, uri.Contains("login"));

        var headers = PrepareHeaders(cookieDic, crypto, realIp, ua);

        var newData = PrepareData(uri, data, crypto, cookieDic, out string url);

        RequestSetting setting = new RequestSetting
        {
            Method = "POST",
            Url = url,
            Headers = headers,
            Data = DicStrUtil.ConvertToQueryString(newData)
        };

        return setting;
    }


    /// <summary>
    /// Prepares the request data and constructs the URL based on the specified crypto method.
    /// </summary>
    /// <param name="uri">The endpoint URI to which the request will be sent.</param>
    /// <param name="data">The request data to be processed.</param>
    /// <param name="crypto">
    /// The encryption method to use ("weapi", "linuxapi", "eapi", or "api"). Defaults to "eapi" or "api"
    /// based on the configuration.
    /// </param>
    /// <param name="cookieDic">
    /// A dictionary of cookies used to retrieve the CSRF token and other necessary data.
    /// </param>
    /// <param name="url">
    /// An output parameter that returns the constructed URL for the request.
    /// </param>
    /// <returns>
    /// A dynamic object containing the prepared data, modified as per the specified crypto method.
    /// </returns>
    /// <remarks>
    /// This method prepares the request data and URL based on the `crypto` value:
    /// - **weapi**: Adds CSRF token and encrypts the data with WeAPI.
    /// - **linuxapi**: Calls a helper method to process Linux API-specific data.
    /// - **eapi/api**: Calls a helper method to prepare the EAPI or API URL.
    /// - **default**: Constructs a URL directly from the domain and URI without additional processing.
    /// </remarks>

    private dynamic PrepareData(string uri, object data, string crypto, Dictionary<string, string> cookieDic, out string url)
    {
        dynamic newData = data?.ToExpandoObject() ?? new ExpandoObject();
        string csrfToken = cookieDic.GetValueOrDefault("__csrf", "");
        crypto = crypto ?? (cfg.Encrypt ? "eapi" : "api");
        crypto = "eapi";
        //TODO debug other crypto model, current set it as eapi defaultly.
        switch (crypto)
        {
            case "weapi":
                newData.csrf_token = csrfToken;
                newData = CryptoUtils.Weapi(newData);
                url = $"{cfg.Domain}/weapi/{uri.Substring(5)}";
                break;

            case "linuxapi":
                newData = PrepareLinuxApiData(uri, data);
                url = $"{cfg.Domain}/api/linux/forward";
                break;

            case "eapi":
            case "api":
                newData = PrepareEapiUrl(uri, newData, null, cookieDic, out url);
                break;

            default:
                url = $"{cfg.Domain}/{uri}";
                break;
        }

        return newData;
    }

    /// <summary>
    /// Prepares the data object for a Linux API request.
    /// </summary>
    /// <param name="uri">The endpoint URI to which the request will be sent.</param>
    /// <param name="data">The parameters to include in the request body.</param>
    /// <returns>
    /// A dynamically constructed object containing the HTTP method, full URL, and parameters.
    /// </returns>
    private dynamic PrepareLinuxApiData(string uri, object data)
    {
        dynamic newData = new ExpandoObject();
        newData.method = "POST";
        newData.url = $"{cfg.Domain}{uri}";
        newData.@params = data;
        return newData;
    }

    /// <summary>
    /// Prepares the EAPI URL and updates the data object with required parameters.
    /// </summary>
    /// <param name="uri">The endpoint URI to which the request will be sent.</param>
    /// <param name="newData">The data object to be enriched with EAPI-specific parameters.</param>
    /// <param name="e_r">
    /// Indicates whether the EAPI response should be encrypted. If null, it will be ignored.
    /// </param>
    /// <param name="cookieDic">
    /// A dictionary of cookies used to retrieve the CSRF token and other required data.
    /// </param>
    /// <returns>
    /// The fully constructed EAPI URL.
    /// </returns>
    /// <remarks>
    /// This method enriches the `newData` object with the CSRF token and optional encryption flags.
    /// It also applies EAPI-specific transformations using <see cref="CryptoUtils.Eapi"/>.
    /// </remarks>
    private dynamic PrepareEapiUrl(string uri, dynamic newData, bool? e_r
        , Dictionary<string, string> cookieDic, out string url)
    {
        if (e_r != null)
        {
            newData.E_R = e_r;
        }

        if (cfg.EncryptResponse)
        {
            newData.E_R = cfg.EncryptResponse;
        }

        newData = CryptoUtils.Eapi(uri, newData);
        url = $"{cfg.Domain}/eapi/{uri.Substring(5)}";
        return newData;
    }

}
