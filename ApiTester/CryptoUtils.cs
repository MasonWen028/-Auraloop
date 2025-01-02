using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTester
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using Newtonsoft.Json;

    public static class CryptoUtils
    {
        private static readonly string iv = "0102030405060708";
        private static readonly string presetKey = "0CoJUm6Qyw8W8jud";
        private static readonly string linuxapiKey = "rFgB&h#%2?^eDg:Q";
        private static readonly string base62 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static readonly string publicKey =
    @"-----BEGIN PUBLIC KEY-----
MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDgtQn2JZ34ZC28NWYpAUd98iZ37BUrX/aKzmFbt7clFSs6sXqHauqKWqdtLkF2KexO40H1YTX8z2lSgBBOAxLsvaklV8k4cBFK9snQXE9/DDaFt6Rr7iVZMldczhC0JNgTz+SHXT6CBHuX3e9SdB1Ua44oncaTWz7OBGLbCiK45wIDAQAB
-----END PUBLIC KEY-----";
        private static readonly string eapiKey = "e82ckenh8dichen8";

        public static string AesEncrypt(string text, string mode, string key, string iv, string format = "base64")
        {
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key);
            if (string.IsNullOrEmpty(iv))
            {
                aes.IV = new byte[16];
            }
            else
            {
                aes.IV = Encoding.UTF8.GetBytes(iv);
            }
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = mode.ToUpper() switch
            {
                "CBC" => CipherMode.CBC,
                "ECB" => CipherMode.ECB,
                _ => throw new ArgumentException("Invalid mode")
            };

            using var encryptor = aes.CreateEncryptor();
            var inputBytes = Encoding.UTF8.GetBytes(text);
            var encrypted = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

            return format == "base64" ? Convert.ToBase64String(encrypted) : BitConverter.ToString(encrypted).Replace("-", "");
        }

        public static string AesDecrypt(string ciphertext, string key, string iv, string format = "base64")
        {
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = string.IsNullOrEmpty(iv) ? new byte[16] : Encoding.UTF8.GetBytes(iv);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.ECB;

            var cipherBytes = format == "base64"
                ? Convert.FromBase64String(ciphertext)
                : ConvertHexStringToBytes(ciphertext);

            using var decryptor = aes.CreateDecryptor();
            var decrypted = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);

            return Encoding.UTF8.GetString(decrypted);
        }

        public static string RsaEncrypt(string text, string publicKey)
        {
            using var rsa = RSA.Create();
            rsa.ImportFromPem(publicKey.ToCharArray());

            var data = Encoding.UTF8.GetBytes(text);
            var encrypted = rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);

            return BitConverter.ToString(encrypted).Replace("-", "").ToLower();
        }

        public static object Weapi(object data)
        {
            var text = JsonConvert.SerializeObject(data);
            var secretKey = GenerateRandomBase62(16);

            var paramsEncrypted = AesEncrypt(AesEncrypt(text, "cbc", presetKey, iv), "cbc", secretKey, iv);
            var encSecKey = RsaEncrypt(secretKey, publicKey);

            return new
            {
                @params = paramsEncrypted,
                encSecKey
            };
        }

        public static object Linuxapi(object data)
        {
            var text = JsonConvert.SerializeObject(data);
            return new
            {
                eparams = AesEncrypt(text, "ecb", linuxapiKey, "", "hex")
            };
        }

        public static object Eapi(string url, object data)
        {
            var text = JsonConvert.SerializeObject(data);
            var message = $"nobody{url}use{text}md5forencrypt";
            var digest = ComputeMd5(message);

            var encryptedData = $"{url}-36cd479b6b5-{text}-36cd479b6b5-{digest}";
            return new
            {
                @params = AesEncrypt(encryptedData, "ecb", eapiKey, "", "hex")
            };
        }

        private static string GenerateRandomBase62(int length)
        {
            var random = new Random();
            var result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(base62[random.Next(base62.Length)]);
            }
            return result.ToString();
        }

        private static string Reverse(string input)
        {
            var charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private static string ComputeMd5(string input)
        {
            using var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }

        private static byte[] ConvertHexStringToBytes(string hex)
        {
            var length = hex.Length / 2;
            var bytes = new byte[length];
            for (int i = 0; i < length; i++)
            {
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return bytes;
        }
    }

}
