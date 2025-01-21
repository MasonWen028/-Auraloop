using NeteaseCloudMusicSDK.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace NeteaseCloudMusicSDK.Utils
{
    /// <summary>
    /// Provides utility methods for cryptographic operations, including AES and RSA encryption/decryption, 
    /// as well as methods for specific API encryption schemes like WeAPI, LinuxAPI, and EAPI.
    /// </summary>
    public static class CryptoUtils
    {
        // Class-wide constants for cryptographic keys, initialization vectors, and configurations
        private static readonly string iv = "0102030405060708"; // Default IV for AES CBC mode
        private static readonly string presetKey = "0CoJUm6Qyw8W8jud"; // Predefined AES key
        private static readonly string linuxapiKey = "rFgB&h#%2?^eDg:Q"; // Key for LinuxAPI encryption
        private static readonly string base62 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; // Characters for base62 encoding
        private static readonly string publicKey =
        @"-----BEGIN PUBLIC KEY-----
MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDgtQn2JZ34ZC28NWYpAUd98iZ37BUrX/aKzmFbt7clFSs6sXqHauqKWqdtLkF2KexO40H1YTX8z2lSgBBOAxLsvaklV8k4cBFK9snQXE9/DDaFt6Rr7iVZMldczhC0JNgTz+SHXT6CBHuX3e9SdB1Ua44oncaTWz7OBGLbCiK45wIDAQAB
-----END PUBLIC KEY-----";
        private static readonly string eapiKey = "e82ckenh8dichen8";

        private static readonly string ID_XOR_KEY_1 = "3go8&$8*3*3h0k(2)2";

        /// <summary>
        /// Encrypts a given plaintext string using AES with the specified mode, key, and IV.
        /// </summary>
        /// <param name="text">The plaintext to encrypt.</param>
        /// <param name="mode">The encryption mode ("CBC" or "ECB").</param>
        /// <param name="key">The AES key.</param>
        /// <param name="iv">The initialization vector (IV).</param>
        /// <param name="format">The output format ("base64" or "hex"). Defaults to "base64".</param>
        /// <returns>The encrypted text in the specified format.</returns>
        /// <exception cref="ArgumentException">Thrown if an invalid mode is specified.</exception>
        public static string AesEncrypt(string text, string mode, string key, string iv, string format = "base64")
        {
            using( var aes = Aes.Create())
            { 
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
                switch (mode.ToUpperInvariant())
                {
                    case "CBC":
                        aes.Mode = CipherMode.CBC;
                        break;
                    case "ECB":
                        aes.Mode = CipherMode.ECB;
                        break;
                    default:
                        throw new ArgumentException($"Invalid mode: {mode}. Supported modes are 'CBC' and 'ECB'.");
                }

                using (var encryptor = aes.CreateEncryptor())
                {
                    var inputBytes = Encoding.UTF8.GetBytes(text);
                    var encrypted = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

                    return format == "base64" ? Convert.ToBase64String(encrypted) : BitConverter.ToString(encrypted).Replace("-", "");
                }
            }
        }

        /// <summary>
        /// Decrypts an AES-encrypted string using the specified key and IV.
        /// </summary>
        /// <param name="ciphertext">The encrypted text to decrypt.</param>
        /// <param name="key">The AES key.</param>
        /// <param name="iv">The initialization vector (IV).</param>
        /// <param name="format">The input format ("base64" or "hex"). Defaults to "base64".</param>
        /// <returns>The decrypted plaintext string.</returns>
        public static string AesDecrypt(string ciphertext, string key, string iv, string format = "base64")
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = string.IsNullOrEmpty(iv) ? new byte[16] : Encoding.UTF8.GetBytes(iv);
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.ECB;

                var cipherBytes = format == "base64"
                    ? Convert.FromBase64String(ciphertext)
                    : ciphertext.ConvertHexStringToBytes();

                using (var decryptor = aes.CreateDecryptor())
                {
                    var decrypted = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);

                    return Encoding.UTF8.GetString(decrypted);
                }
            }
        }

        /// <summary>
        /// Extracts the base64-encoded bytes from a PEM-formatted string.
        /// </summary>
        /// <param name="pem">The PEM-formatted string.</param>
        /// <param name="header">The type of key (e.g., "PUBLIC KEY").</param>
        /// <returns>The extracted bytes from the base64-encoded content.</returns>
        private static byte[] GetBytesFromPem(string pem, string header)
        {
            // Define the header and footer lines based on the key type
            var headerLine = $"-----BEGIN {header}-----";
            var footerLine = $"-----END {header}-----";

            // Locate the start and end positions of the base64 content
            var start = pem.IndexOf(headerLine) + headerLine.Length;
            var end = pem.IndexOf(footerLine, start);

            if (start < headerLine.Length || end < 0)
            {
                throw new ArgumentException("The provided PEM string is invalid.");
            }

            // Extract the base64 content, trim any whitespace, and decode to bytes
            var base64 = pem.Substring(start, end - start).Trim();
            return Convert.FromBase64String(base64);
        }


        /// <summary>
        /// Imports an RSA public key from a PEM-formatted string.
        /// </summary>
        /// <param name="pem">
        /// A PEM-formatted public key string, typically starting with "-----BEGIN PUBLIC KEY-----" 
        /// and ending with "-----END PUBLIC KEY-----".
        /// </param>
        /// <returns>
        /// An <see cref="RSACryptoServiceProvider"/> instance initialized with the imported RSA public key.
        /// </returns>
        /// <remarks>
        /// This method parses the PEM-encoded public key and extracts the key's modulus and exponent
        /// using ASN.1 structure parsing. The extracted parameters are then used to initialize 
        /// an <see cref="RSACryptoServiceProvider"/> instance.
        ///
        /// Key Steps:
        /// 1. The PEM string is processed to extract the base64-encoded public key bytes.
        /// 2. The public key bytes are parsed as an ASN.1 structure to extract the modulus and exponent.
        /// 3. These values are used to populate an <see cref="RSAParameters"/> object, which is then 
        ///    imported into an <see cref="RSACryptoServiceProvider"/> instance.
        ///
        /// **Notes**:
        /// - This implementation assumes the public key uses the ASN.1 DER encoding.
        /// - The function supports RSA public keys but does not handle private keys.
        /// </remarks>
        /// <example>
        /// Example usage:
        /// <code>
        /// string publicKeyPem = @"-----BEGIN PUBLIC KEY-----
        /// MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDgtQn2JZ34ZC28NWYpAUd98iZ3
        /// 7BUrX/aKzmFbt7clFSs6sXqHauqKWqdtLkF2KexO40H1YTX8z2lSgBBOAxLsvakl
        /// V8k4cBFK9snQXE9/DDaFt6Rr7iVZMldczhC0JNgTz+SHXT6CBHuX3e9SdB1Ua44o
        /// ncaTWz7OBGLbCiK45wIDAQAB
        /// -----END PUBLIC KEY-----";
        ///
        /// RSA rsa = ImportPublicKey(publicKeyPem);
        /// byte[] encryptedData = rsa.Encrypt(Encoding.UTF8.GetBytes("Hello"), false);
        /// Console.WriteLine(BitConverter.ToString(encryptedData).Replace("-", ""));
        /// </code>
        /// </example>
        private static RSA ImportPublicKey(string pem)
        {
            byte[] seqOid = { 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00 };
            byte[] seq = new byte[15];

            var x509Key = GetBytesFromPem(pem, "PUBLIC KEY");

            // ---------  Set up stream to read the asn.1 encoded SubjectPublicKeyInfo blob  ------
            using (MemoryStream mem = new MemoryStream(x509Key))
            {
                using (BinaryReader binr = new BinaryReader(mem))  //wrap Memory Stream with BinaryReader for easy reading
                {
                    byte bt = 0;
                    ushort twobytes = 0;

                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                        binr.ReadByte();    //advance 1 byte
                    else if (twobytes == 0x8230)
                        binr.ReadInt16();   //advance 2 bytes
                    else
                        return null;

                    seq = binr.ReadBytes(15);       //read the Sequence OID
                    if (!CompareBytearrays(seq, seqOid))    //make sure Sequence for OID is correct
                        return null;

                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8103) //data read as little endian order (actual data order for Bit String is 03 81)
                        binr.ReadByte();    //advance 1 byte
                    else if (twobytes == 0x8203)
                        binr.ReadInt16();   //advance 2 bytes
                    else
                        return null;

                    bt = binr.ReadByte();
                    if (bt != 0x00)     //expect null byte next
                        return null;

                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                        binr.ReadByte();    //advance 1 byte
                    else if (twobytes == 0x8230)
                        binr.ReadInt16();   //advance 2 bytes
                    else
                        return null;

                    twobytes = binr.ReadUInt16();
                    byte lowbyte = 0x00;
                    byte highbyte = 0x00;

                    if (twobytes == 0x8102) //data read as little endian order (actual data order for Integer is 02 81)
                        lowbyte = binr.ReadByte();  // read next bytes which is bytes in modulus
                    else if (twobytes == 0x8202)
                    {
                        highbyte = binr.ReadByte(); //advance 2 bytes
                        lowbyte = binr.ReadByte();
                    }
                    else
                        return null;
                    byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };   //reverse byte order since asn.1 key uses big endian order
                    int modsize = BitConverter.ToInt32(modint, 0);

                    int firstbyte = binr.PeekChar();
                    if (firstbyte == 0x00)
                    {   //if first byte (highest order) of modulus is zero, don't include it
                        binr.ReadByte();    //skip this null byte
                        modsize -= 1;   //reduce modulus buffer size by 1
                    }

                    byte[] modulus = binr.ReadBytes(modsize);   //read the modulus bytes

                    if (binr.ReadByte() != 0x02)            //expect an Integer for the exponent data
                        return null;
                    int expbytes = (int)binr.ReadByte();        // should only need one byte for actual exponent data (for all useful values)
                    byte[] exponent = binr.ReadBytes(expbytes);

                    // ------- create RSACryptoServiceProvider instance and initialize with public key -----
                    var rsa = RSA.Create();
                    RSAParameters rsaKeyInfo = new RSAParameters
                    {
                        Modulus = modulus,
                        Exponent = exponent
                    };
                    rsa.ImportParameters(rsaKeyInfo);

                    return rsa;
                }
            }
        }

        /// <summary>
        /// Compare 2 byte arraies
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static bool CompareBytearrays(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;
            int i = 0;
            foreach (byte c in a)
            {
                if (c != b[i])
                    return false;
                i++;
            }
            return true;
        }

        /// <summary>
        /// Encrypts a string using RSA with the specified public key.
        /// </summary>
        /// <param name="text">The plaintext to encrypt.</param>
        /// <param name="publicKey">The RSA public key in PEM format.</param>
        /// <returns>The encrypted text as a lowercase hexadecimal string.</returns>
        public static string RsaEncrypt(string text, string publicKey)
        {
            // Import the public key
            var rsa = ImportPublicKey(publicKey);
            var rsaParameters = rsa.ExportParameters(false); // Only public key data is needed

            // Convert the plaintext into bytes
            var data = Encoding.UTF8.GetBytes(text);

            // Use the low-level RSA encryption logic
            var encryptedBytes = RsaEncryptLowLevel(data, rsaParameters);

            // Convert the encrypted bytes to a hexadecimal string
            return BitConverter.ToString(encryptedBytes).Replace("-", "").ToLower();
        }

        private static byte[] RsaEncryptLowLevel(byte[] buffer, RSAParameters key)
        {
            return GetByteArrayBigEndian(BigInteger.ModPow(
                GetBigIntegerBigEndian(buffer),
                GetBigIntegerBigEndian(key.Exponent),
                GetBigIntegerBigEndian(key.Modulus)));
        }

        private static byte[] GetByteArrayBigEndian(BigInteger value)
        {
            byte[] array = value.ToByteArray();
            if (array[array.Length - 1] == 0)
            {
                byte[] array2 = new byte[array.Length - 1];
                Buffer.BlockCopy(array, 0, array2, 0, array2.Length);
                array = array2;
            }
            Array.Reverse(array);
            return array;
        }

        private static BigInteger GetBigIntegerBigEndian(byte[] value)
        {
            byte[] value2 = new byte[value.Length + 1];
            for (int i = 0; i < value.Length; i++)
                value2[value2.Length - i - 2] = value[i];
            return new BigInteger(value2);
        }

        /// <summary>
        /// Encrypts data using the WeAPI encryption scheme (double AES encryption with RSA key exchange).
        /// </summary>
        /// <param name="data">The data object to encrypt.</param>
        /// <returns>An object containing the encrypted parameters and RSA-encrypted secret key.</returns>
        public static object Weapi(object data)
        {
            var text = JsonConvert.SerializeObject(data);
            var secretKey = RandomStringUtil.GenerateRandomBase62(16);

            var aesOne = AesEncrypt(text, "cbc", presetKey, iv);


            var paramsEncrypted = AesEncrypt(aesOne, "cbc", secretKey, iv );

            var encSecKey = RsaEncrypt(new string(secretKey.ToCharArray().Reverse().ToArray()), publicKey);

            return new
            {
                @params = paramsEncrypted,
                encSecKey
            };
        }

        /// <summary>
        /// Encrypts data using the LinuxAPI encryption scheme (AES ECB mode).
        /// </summary>
        /// <param name="data">The data object to encrypt.</param>
        /// <returns>An object containing the encrypted parameters for the LinuxAPI.</returns>
        public static object Linuxapi(object data)
        {
            var text = JsonConvert.SerializeObject(data);
            return new
            {
                eparams = AesEncrypt(text, "ecb", linuxapiKey, "", "hex")
            };
        }

        /// <summary>
        /// Encrypts data using the EAPI encryption scheme (custom encryption combining MD5 and AES).
        /// </summary>
        /// <param name="url">The API endpoint URL.</param>
        /// <param name="data">The data object to encrypt.</param>
        /// <returns>An object containing the encrypted parameters for the EAPI.</returns>
        public static object Eapi(string url, object data)
        {
            var text = JsonConvert.SerializeObject(data, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver {
                    IgnoreSerializableAttribute = false
                }
            });
            var message = $"nobody{url}use{text}md5forencrypt";
            var digest = message.CalculateMd5();

            var encryptedData = $"{url}-36cd479b6b5-{text}-36cd479b6b5-{digest}";
            return new
            {
                @params = AesEncrypt(encryptedData, "ecb", eapiKey, "", "hex")
            };
        }


        /// <summary>
        /// Decrypt response string
        /// </summary>
        /// <param name="encryptedString"></param>
        /// <returns></returns>
        public static string EapiResDecrypt(string encryptedString)
        {
            string str = ConvertToBase64(encryptedString);
            return AesDecrypt(str, eapiKey, "");
        }

        /// <summary>
        /// Convert a string into base64 format
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string ConvertToBase64(string input)
        {
            // Convert the input string to a byte array
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Convert the byte array to a Base64 string
            return Convert.ToBase64String(inputBytes);
        }


        /// <summary>
        /// Encode id
        /// </summary>
        /// <param name="someId"></param>
        /// <returns></returns>
        public static string CloudMusicDllEncodeId(string someId)
        {
            // 1. XOR each character
            StringBuilder xoredStringBuilder = new StringBuilder();
            for (int i = 0; i < someId.Length; i++)
            {
                // ^ in C# will XOR the numeric (Unicode) value of the chars
                char xoredChar = (char)(someId[i] ^ ID_XOR_KEY_1[i % ID_XOR_KEY_1.Length]);
                xoredStringBuilder.Append(xoredChar);
            }

            // Convert the xored string to UTF-8 bytes
            byte[] xoredBytes = Encoding.UTF8.GetBytes(xoredStringBuilder.ToString());

            // 2. Compute MD5
            using (MD5 md5 = MD5.Create())
            {
                byte[] digestBytes = md5.ComputeHash(xoredBytes);

                // 3. Convert MD5 digest to Base64
                return Convert.ToBase64String(digestBytes);
            }
        }

    }

}
