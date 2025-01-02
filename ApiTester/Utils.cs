using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ApiTester
{
    public class Utils
    {
        /// <summary>
        /// convert inputed string into a dictionary
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Dictionary<string, string> StringToDictionary(string input)
        {
            var result = new Dictionary<string, string>();

            try
            {
                // Check if the string is JSON
                if (input.TrimStart().StartsWith("{") && input.TrimEnd().EndsWith("}"))
                {
                    // Deserialize JSON string into a dictionary
                    result = JsonConvert.DeserializeObject<Dictionary<string, string>>(input);
                }
                else
                {
                    // Parse as key-value pairs (e.g., A=1;B=2)
                    var pairs = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var pair in pairs)
                    {
                        var keyValue = pair.Split(new[] { '=' }, 2);
                        if (keyValue.Length == 2)
                        {
                            var key = keyValue[0].Trim();
                            var value = keyValue[1].Trim();
                            result[key] = value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing input: {ex.Message}");
            }

            return result;
        }

        /// <summary>
        /// convert inputed dictionary into a string
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static string DictionaryToString(Dictionary<string, string> dictionary)
        {
            var parts = new List<string>();

            foreach (var kvp in dictionary)
            {
                parts.Add($"{kvp.Key}={kvp.Value}");
            }

            return string.Join("; ", parts) + ";";
        }

        /// <summary>
        /// convert an object to string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ConvertToQueryString(object obj)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            foreach (var property in obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                var value = property.GetValue(obj);
                if (value != null)
                {
                    queryString[property.Name] = value.ToString();
                }
            }

            return queryString.ToString();
        }

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
    }
}
