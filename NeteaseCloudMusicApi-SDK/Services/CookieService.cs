using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace NeteaseCloudMusicApi_SDK.Services
{
    

    public class CookieService
    {
        private readonly string anonymousToken = "your_anonymous_token"; // Replace with your predefined anonymous token.
        private readonly string deviceIdFilePath = Path.Combine(AppContext.BaseDirectory, "Static/deviceid.txt");

        public string GenerateCookies(RequestOptions options)
        {
            var cookie = ParseCookie(options.Cookie);
            string _ntes_nuid = GenerateRandomHex(32);
            string _ntes_nnid = $"{_ntes_nuid},{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}";

            // Add default cookies
            cookie["__remember_me"] = "true";
            cookie["_ntes_nuid"] = cookie.ContainsKey("_ntes_nuid") ? cookie["_ntes_nuid"] : _ntes_nuid;
            cookie["_ntes_nnid"] = cookie.ContainsKey("_ntes_nnid") ? cookie["_ntes_nnid"] : _ntes_nnid;

            // Add NMTID if not a login request
            if (options.Uri!= null && !options.Uri.Contains("login"))
            {
                cookie["NMTID"] = GenerateRandomHex(16);
            }

            // Add MUSIC_A if MUSIC_U is missing
            if (!cookie.ContainsKey("MUSIC_U"))
            {
                cookie["MUSIC_A"] = anonymousToken;
            }

            // Add or get a deviceId
            if (!cookie.ContainsKey("deviceId"))
            {
                cookie["deviceId"] = GetRandomDeviceId();
            }

            return SerializeCookies(cookie);
        }

        private string GetRandomDeviceId()
        {
            try
            {
                if (!File.Exists(deviceIdFilePath))
                {
                    throw new FileNotFoundException($"DeviceId file not found: {deviceIdFilePath}");
                }

                var deviceIds = File.ReadAllLines(deviceIdFilePath).Where(line => !string.IsNullOrWhiteSpace(line)).ToList();
                if (deviceIds.Count == 0)
                {
                    throw new InvalidOperationException("No valid deviceIds found in the file.");
                }

                var randomIndex = new Random().Next(0, deviceIds.Count);
                return deviceIds[randomIndex];
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to load a random deviceId.", ex);
            }
        }

        private Dictionary<string, string> ParseCookie(string cookieString)
        {
            return string.IsNullOrEmpty(cookieString)
                ? new Dictionary<string, string>()
                : cookieString.Split(';')
                    .Select(part => part.Split('='))
                    .ToDictionary(parts => parts[0].Trim(), parts => parts.Length > 1 ? parts[1].Trim() : "");
        }

        private string SerializeCookies(Dictionary<string, string> cookie)
        {
            return string.Join("; ", cookie.Select(kvp => $"{kvp.Key}={kvp.Value}"));
        }

        private string GenerateRandomHex(int length)
        {
            using var rng = new RNGCryptoServiceProvider();
            var bytes = new byte[length / 2];
            rng.GetBytes(bytes);
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }


}
