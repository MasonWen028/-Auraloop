using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing topics and related details in the Netease Cloud Music API.
    /// </summary>
    public interface ITopicService
    {
        /// <summary>
        /// Retrieves detailed information about a specific topic.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching topic details.</param>
        /// <returns>An <see cref="ApiResponse"/> containing topic details.</returns>
        Task<ApiResponse> Detail(TopicDetailRequestModel requestModel);

        /// <summary>
        /// Retrieves hot events for a specific topic.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching hot events of a topic.</param>
        /// <returns>An <see cref="ApiResponse"/> containing hot events of the topic.</returns>
        Task<ApiResponse> DetailEventHot(TopicDetailRequestModel requestModel);

        /// <summary>
        /// Retrieves the user's subscribed topic list with pagination.
        /// </summary>
        /// <param name="requestModel">The model containing pagination parameters.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the subscribed topic list.</returns>
        Task<ApiResponse> Sublist(TopicSublistRequestModel requestModel);


        /// <summary>
        /// Retrieves a list of trending or popular topics.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the list of hot topics.</returns>
        Task<ApiResponse> Hot();
    }
}
