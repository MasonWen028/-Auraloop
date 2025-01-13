using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text;

namespace NeteaseCloudMusicSDK.Models.Response
{
    /// <summary>
    /// Standard response model for API interactions.
    /// </summary>
    /// <typeparam name="T">The type of data returned in the response.</typeparam>
    public class ApiResponse
    {
        /// <summary>
        /// Indicates whether the API request was successful.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// The main data payload of the response (if applicable).
        /// </summary>
        public Object Data { get; set; }

        /// <summary>
        /// if the response set the cookie, return it to request
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Cookie { get; set; }

        /// <summary>
        /// An error message or reason for failure (if applicable).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// A list of validation errors (if applicable).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> ValidationErrors { get; set; }

        /// <summary>
        /// Metadata associated with the response (optional).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object Metadata { get; set; }

        /// <summary>
        /// A unique request ID for debugging and tracking purposes.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string RequestId { get; set; }

        /// <summary>
        /// The HTTP status code of the response.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Factory method to create a successful response.
        /// </summary>
        public static ApiResponse Success(Object data, object metadata = null, string requestId = null)
        {
            return new ApiResponse
            {
                IsSuccess = true,
                Data = data,
                Metadata = metadata,
                RequestId = requestId,
                StatusCode = 200
            };
        }

        /// <summary>
        /// Factory method to create an error response.
        /// </summary>
        public static ApiResponse Error(string errorMessage, int statusCode = 400, List<string> validationErrors = null, string requestId = null)
        {
            return new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = errorMessage,
                ValidationErrors = validationErrors,
                StatusCode = statusCode,
                RequestId = requestId
            };
        }
    }
}
