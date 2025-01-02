using System.Security.Cryptography;
using System.Text;


namespace NeteaseCloudMusicApi_SDK.Services
{
    public class EncryptionService
    {
        private const string Iv = "0102030405060708";
        private const string PresetKey = "0CoJUm6Qyw8W8jud";
        private const string LinuxApiKey = "rFgB&h#%2?^eDg:Q";
        private const string EApiKey = "e82ckenh8dichen8";

        private static readonly string PublicKey = @"-----BEGIN PUBLIC KEY-----
MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDgtQn2JZ34ZC28NWYpAUd98iZ37BUrX/aKzmFbt7clFSs6sXqHauqKWqdtLkF2KexO40H1YTX8z2lSgBBOAxLsvaklV8k4cBFK9snQXE9/DDaFt6Rr7iVZMldczhC0JNgTz+SHXT6CBHuX3e9SdB1Ua44oncaTWz7OBGLbCiK45wIDAQAB
-----END PUBLIC KEY-----";

        // AES Encryption
        public string AesEncrypt(string text, string key, string iv, CipherMode mode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);
                aes.Mode = mode;
                aes.Padding = padding;

                using (var encryptor = aes.CreateEncryptor())
                {
                    var inputBuffer = Encoding.UTF8.GetBytes(text);
                    var encrypted = encryptor.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                    return Convert.ToBase64String(encrypted);
                }
            }
        }

        // AES Decryption
        public string AesDecrypt(string ciphertext, string key, string iv, CipherMode mode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);
                aes.Mode = mode;
                aes.Padding = padding;

                using (var decryptor = aes.CreateDecryptor())
                {
                    var encryptedBytes = Convert.FromBase64String(ciphertext);
                    var decrypted = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                    return Encoding.UTF8.GetString(decrypted);
                }
            }
        }

        // RSA Encryption
        public string RsaEncrypt(string text, string publicKey)
        {
            using (var rsa = RSA.Create())
            {
                rsa.ImportFromPem(publicKey.ToCharArray());
                var bytes = Encoding.UTF8.GetBytes(text);
                var encryptedBytes = rsa.Encrypt(bytes, RSAEncryptionPadding.Pkcs1);
                return Convert.ToHexString(encryptedBytes).ToLower();
            }
        }

        // WeAPI Encryption
        public object WeApiEncrypt(object data)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(data);
            var secretKey = GenerateRandomString(16);
            var encryptedText = AesEncrypt(json, PresetKey, Iv);
            var doubleEncryptedText = AesEncrypt(encryptedText, secretKey, Iv);
            var encSecKey = RsaEncrypt(new string(secretKey.Reverse().ToArray()), PublicKey);

            return new
            {
                @params = doubleEncryptedText,
                encSecKey
            };
        }

        // LinuxAPI Encryption
        public object LinuxApiEncrypt(object data)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(data);
            var encryptedText = AesEncrypt(json, LinuxApiKey, null, CipherMode.ECB, PaddingMode.PKCS7);
            return new { eparams = encryptedText };
        }

        // EAPI Encryption
        public object EApiEncrypt(string url, object data)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(data);
            var message = $"nobody{url}use{json}md5forencrypt";
            var md5Hash = CreateMd5Hash(message);
            var combinedData = $"{url}-36cd479b6b5-{json}-36cd479b6b5-{md5Hash}";
            var encryptedData = AesEncrypt(combinedData, EApiKey, null, CipherMode.ECB, PaddingMode.PKCS7);
            return new { @params = encryptedData };
        }

        public object EApiResDecrypt(string encryptedData)
        {
            // Decrypt the encrypted data using AES
            var decryptedString = AesDecrypt(encryptedData, EApiKey, null, CipherMode.ECB, PaddingMode.PKCS7);

            // Split the decrypted string to extract URL and data
            var parts = decryptedString.Split("-36cd479b6b5-");
            if (parts.Length != 3)
            {
                throw new InvalidOperationException("Invalid encrypted data format.");
            }

            var url = parts[0];
            var jsonData = parts[1];
            var hash = parts[2];

            // Validate the hash (optional)
            var expectedHash = CreateMd5Hash($"nobody{url}use{jsonData}md5forencrypt");
            if (hash != expectedHash)
            {
                throw new InvalidOperationException("Hash validation failed.");
            }

            // Deserialize the JSON data
            return System.Text.Json.JsonSerializer.Deserialize<object>(jsonData);
        }

        // MD5 Hash Generation
        private string CreateMd5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.UTF8.GetBytes(input);
                var hashBytes = md5.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        // Helper: Generate Random String
        private string GenerateRandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }


}
