using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace NeteaseCloudMusicSDK.Utils
{
    /// <summary>
    /// A utility class for generating random string
    /// </summary>
    public static class RandomStringUtil
    {
        static readonly string base62 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        /// <summary>
        /// generate a string by inputed byteLength
        /// </summary>
        /// <param name="byteLength"></param>
        /// <returns></returns>
        public static string GenerateRandomString(int byteLength)
        {
            // Generate random bytes
            using (var rng = RandomNumberGenerator.Create())
            {
                var randomBytes = new byte[byteLength];
                rng.GetBytes(randomBytes);

                // Convert to hexadecimal string
                var sb = new StringBuilder(byteLength * 2);
                foreach (var b in randomBytes)
                {
                    sb.AppendFormat("{0:x2}", b);
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// Generates a random string of the specified length using Base62 characters.
        /// </summary>
        /// <param name="length">
        /// The length of the random string to generate.
        /// </param>
        /// <returns>
        /// A string consisting of randomly selected characters from the Base62 character set, 
        /// which includes lowercase letters, uppercase letters, and digits (a-z, A-Z, 0-9).
        /// </returns>
        /// <remarks>
        /// This method creates a random string using the Base62 character set, 
        /// which is often used for creating compact and URL-safe identifiers or tokens. 
        /// 
        /// **Key Features**:
        /// - The Base62 character set ensures a compact representation with no special characters.
        /// - Uses <see cref="System.Text.StringBuilder"/> for efficient string concatenation.
        /// - Relies on <see cref="System.Random"/> for generating random indices into the character set.
        ///
        /// **Limitations**:
        /// - The randomness relies on <see cref="System.Random"/>, which is not cryptographically secure. 
        ///   If cryptographic security is required, consider using <see cref="System.Security.Cryptography.RandomNumberGenerator"/> instead.
        ///
        /// **Examples**:
        /// <code>
        /// string randomString = GenerateRandomBase62(10); // Example output: "aZ3bY7xF5C"
        /// </code>
        /// </remarks>
        public static string GenerateRandomBase62(int length)
        {
            var random = new Random();
            var result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(base62[random.Next(base62.Length)]);
            }
            return result.ToString();
        }
    }
}
