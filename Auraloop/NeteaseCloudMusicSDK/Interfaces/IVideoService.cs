using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing video-related data in the Netease Cloud Music API.
    /// </summary>
    public interface IVideoService
    {
        /// <summary>
        /// Retrieves a list of video categories with pagination.
        /// </summary>
        /// <param name="requestModel">The model containing pagination parameters.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the video category list.</returns>
        Task<ApiResponse> CategoryList(VideoCategoryListRequestModel requestModel);

        /// <summary>
        /// Retrieves detailed information about a specific video.
        /// </summary>
        /// <param name="id">The unique identifier of the video.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the video details.</returns>
        Task<ApiResponse> Detail(long id);

        /// <summary>
        /// Retrieves detailed information about a video's likes, shares, and comments.
        /// </summary>
        /// <param name="vid">The unique identifier of the video.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the video's interaction details.</returns>
        Task<ApiResponse> DetailInfo(long vid);

        /// <summary>
        /// Retrieves videos within a specific group or category.
        /// </summary>
        /// <param name="requestModel">The model containing group and pagination parameters.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the videos in the group.</returns>
        Task<ApiResponse> Group(VideoGroupRequestModel requestModel);

        /// <summary>
        /// Retrieves a list of video groups or tags.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the video group list.</returns>
        Task<ApiResponse> GroupList();

        /// <summary>
        /// Subscribes or unsubscribes to a specific video.
        /// </summary>
        /// <param name="id">The unique identifier of the video.</param>
        /// <param name="subscribe">A boolean indicating whether to subscribe (true) or unsubscribe (false).</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> Sub(long id, bool subscribe);

        /// <summary>
        /// Retrieves a timeline of all videos with pagination.
        /// </summary>
        /// <param name="requestModel">The model containing pagination parameters.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the video timeline.</returns>
        Task<ApiResponse> TimelineAll(VideoTimelineRequestModel requestModel);

        /// <summary>
        /// Retrieves a timeline of recommended videos with pagination.
        /// </summary>
        /// <param name="requestModel">The model containing pagination parameters.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the recommended video timeline.</returns>
        Task<ApiResponse> TimelineRecommend(VideoTimelineRecommendRequestModel requestModel);

        /// <summary>
        /// Retrieves the playback URL of a specific video.
        /// </summary>
        /// <param name="id">The unique identifier of the video.</param>
        /// <param name="resolution">The desired resolution of the video. Default is 1080.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the video playback URL.</returns>
        Task<ApiResponse> Url(long id, int resolution = 1080);
    }
}
