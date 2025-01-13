using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace NeteaseCloudMusicSDK.Utils
{
    /// <summary>
    /// A utility class for operation between string and dictionary
    /// </summary>
    public static class DicStrUtil
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
        public static string DictionaryToString(this Dictionary<string, string> dictionary)
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
        /// Gets the value associated with the specified key from the dictionary.
        /// If the key does not exist, returns the default value for the value type <typeparamref name="TValue"/>.
        /// </summary>
        /// <typeparam name="Tkey">The type of the dictionary's key.</typeparam>
        /// <typeparam name="TValue">The type of the dictionary's value.</typeparam>
        /// <param name="dic">The dictionary to search.</param>
        /// <param name="key">The key whose value is to be retrieved.</param>
        /// <returns>
        /// The value associated with the specified key, or the default value for type <typeparamref name="T"/> if the key does not exist.
        /// </returns>
        public static TValue GetValueOrDefault<Tkey, TValue>(this Dictionary<Tkey, TValue> dic, Tkey key, TValue defaultValue)
        {
            if (dic == null || !dic.ContainsKey(key))
            {
                return defaultValue;
            }
            return dic[key];
        }


        /// <summary>
        /// Gets the value associated with the specified key from the dictionary.
        /// If the key does not exist, returns the default value for the value type <typeparamref name="TValue"/>.
        /// </summary>
        /// <typeparam name="Tkey">The type of the dictionary's key.</typeparam>
        /// <param name="dic">The dictionary to search.</param>
        /// <param name="key">The key whose value is to be retrieved.</param>
        /// <returns>
        /// The value associated with the specified key, or the default value for type <typeparamref name="T"/> if the key does not exist.
        /// </returns>
        public static TValue GetValueOrDefault<Tkey, TValue>(this Dictionary<Tkey, TValue> dic, Tkey key)
        {
            if (dic == null || !dic.ContainsKey(key))
            {
                return default;
            }
            return dic[key];
        }

    }
}
