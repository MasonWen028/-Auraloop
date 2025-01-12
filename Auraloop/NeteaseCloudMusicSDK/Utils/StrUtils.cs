using System;
using System.Collections.Generic;
using System.Text;

namespace NeteaseCloudMusicSDK.Utils
{
    public static class StrUtils
    {
        public static string ProcessInitial(this string input)
        {
            // Check if the input is a number
            if (int.TryParse(input, out int numericValue))
            {
                return numericValue + ""; // Return the numeric value directly
            }
            else
            {
                // Check if the input is a non-empty string
                if (!string.IsNullOrEmpty(input))
                {
                    // Convert to uppercase and get the ASCII/Unicode code of the first character
                    return (int)char.ToUpper(input[0]) + ""; // ASCII/Unicode value
                }
                else
                {
                    // Return null (equivalent to undefined in JavaScript)
                    return "";
                }
            }
        }


        /// <summary>
        /// Convert a string to base64 string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToBase64Str(this string str)
        {
            var byteArr = Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(byteArr);
        }
    }
}
