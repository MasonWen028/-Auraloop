using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing personalized recommendations in the Netease Cloud Music API.
    /// </summary>
    public interface IRecommendService
    {
        /// <summary>
        /// Retrieves a list of recommended resources, such as playlists or albums.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing recommended resources.</returns>
        Task<ApiResponse> Resource();

        /// <summary>
        /// Retrieves a list of recommended songs based on the user's listening preferences.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing recommended songs.</returns>
        Task<ApiResponse> Songs();

        /// <summary>
        /// Marks specific songs as disliked to influence future recommendations.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the dislike operation.</returns>
        Task<ApiResponse> SongsDislike(RecommendSongsDislikeRequestModel requestModel);
    }
}
