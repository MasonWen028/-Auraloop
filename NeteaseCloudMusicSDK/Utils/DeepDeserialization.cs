using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace NeteaseCloudMusicSDK.Utils
{
    public static class DeepDeserialization
    {
        /// <summary>
        /// Deep Deserialize JSON string into a Dictionary<string, object> with flattened structure.
        /// </summary>
        /// <param name="json">The JSON string to deserialize.</param>
        /// <returns>A simplified dictionary structure.</returns>
        public static Dictionary<string, object> DeepDeserialize(this string json)
        {
            var parsedObject = JObject.Parse(json);
            return ProcessJTokenToDictionary(parsedObject);
        }

        private static Dictionary<string, object> ProcessJTokenToDictionary(JToken token)
        {
            var result = new Dictionary<string, object>();

            if (token is JObject jObject)
            {
                foreach (var property in jObject.Properties())
                {
                    result[property.Name] = ProcessJToken(property.Value);
                }
            }
            else if (token is JArray jArray)
            {
                var list = new List<object>();
                foreach (var item in jArray)
                {
                    list.Add(ProcessJToken(item));
                }
                result["Array"] = list; // Store array under "Array" key
            }
            else
            {
                // Handle primitives directly
                return new Dictionary<string, object> { { "Value", token.ToObject<object>() } };
            }

            return result;
        }

        private static object ProcessJToken(JToken token)
        {
            if (token is JObject)
            {
                return ProcessJTokenToDictionary(token);
            }
            else if (token is JArray jArray)
            {
                var list = new List<object>();
                foreach (var item in jArray)
                {
                    list.Add(ProcessJToken(item));
                }
                return list;
            }
            else
            {
                // Return primitive values directly
                return token.ToObject<object>();
            }
        }
    }
}
