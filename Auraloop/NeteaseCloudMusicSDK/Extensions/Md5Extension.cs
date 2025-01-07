using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace NeteaseCloudMusicSDK.Extensions
{
    /// <summary>
    /// A utility class for calculating md5 of string, file and byte array.
    /// </summary>
    public static class Md5Extension
    {
        /// <summary>
        /// Calculates the MD5 hash of a given byte array.
        /// </summary>
        /// <param name="data">The byte array to hash.</param>
        /// <returns>The MD5 hash as a hexadecimal string.</returns>
        public static string CalculateMd5(this byte[] data)
        {
            using (var md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(data);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        /// <summary>
        /// Calculates the MD5 hash of a given uploaded file.
        /// </summary>
        /// <param name="file">The file to hash.</param>
        /// <returns>The MD5 hash as a hexadecimal string.</returns>
        public static string CalculateMd5(this IFormFile file)
        {
            byte[] data = file.ReadFileBytes();
            using (var md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(data);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        /// <summary>
        /// Calculates the MD5 hash of a file stream.
        /// </summary>
        /// <param name="stream">The file stream to hash.</param>
        /// <returns>The MD5 hash as a hexadecimal string.</returns>
        public static string CalculateMd5(this Stream stream)
        {
            using (var md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(stream);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        /// <summary>
        /// convert iformfile to byte array
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static byte[] ReadFileBytes(this IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Generates the MD5 hash of a given string.
        /// </summary>
        /// <param name="input">The input string to hash.</param>
        /// <returns>The MD5 hash as a lowercase hexadecimal string.</returns>
        public static string CalculateMd5(this string input)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.UTF8.GetBytes(input);
                var hashBytes = md5.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
