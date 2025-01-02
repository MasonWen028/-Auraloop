using Newtonsoft.Json;
using System.Dynamic;
using System.Reflection;

namespace NeteaseCloudMusicApi_SDK.Helpers.Extensions
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Converts a strongly-typed object into an ExpandoObject.
        /// </summary>
        /// <param name="data">The source object.</param>
        /// <returns>A dynamic ExpandoObject with properties from the source object.</returns>
        public static ExpandoObject ToExpandoObject(this object data)
        {
            if (data == null)
                return null;

            var expando = new ExpandoObject() as IDictionary<string, object>;

            foreach (var property in data.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                // Check if the property has a JsonProperty attribute
                var jsonPropertyAttribute = property
                    .GetCustomAttributes(typeof(JsonPropertyAttribute), true)
                    .FirstOrDefault() as JsonPropertyAttribute;

                // Use the attribute value if present; otherwise, use the property name
                var propertyName = jsonPropertyAttribute?.PropertyName ?? property.Name;
                var propertyValue = property.GetValue(data);

                // Add the property to the expando
                expando[propertyName] = propertyValue;
            }

            return (ExpandoObject)expando;
        }

        /// <summary>
        /// Converts an object's properties into an encoded key-value pair string, separated by "; ".
        /// </summary>
        /// <param name="obj">The object to convert.</param>
        /// <returns>A string of encoded key-value pairs.</returns>
        public static string ToEncodedHeaderString(this object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            var properties = obj.GetType().GetProperties();

            return string.Join("; ",
                properties.Select(prop =>
                {
                    var key = Uri.EscapeDataString(prop.Name);
                    var value = Uri.EscapeDataString(prop.GetValue(obj)?.ToString() ?? string.Empty);
                    return $"{key}={value}";
                }));
        }
    }
}
