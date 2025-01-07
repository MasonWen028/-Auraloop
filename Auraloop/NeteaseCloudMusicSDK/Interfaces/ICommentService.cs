using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing comments across various entities in the Netease Cloud Music API.
    /// </summary>
    public interface ICommentService
    {
        /// <summary>
        /// Sends, deletes, or replies to a comment.
        /// </summary>
        /// <param name="requestModel">The request model containing parameters for the comment operation.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> ManageComment(CommentManageRequestModel requestModel);

        /// <summary>
        /// Retrieves comments for a specific album.
        /// </summary>
        /// <param name="requestModel">The request model containing parameters for fetching album comments.</param>
        /// <returns>An <see cref="ApiResponse"/> containing album comments.</returns>
        Task<ApiResponse> GetAlbumComments(CommentRequestModel requestModel);

        /// <summary>
        /// Retrieves comments for a specific DJ program.
        /// </summary>
        /// <param name="requestModel">The request model containing parameters for fetching DJ comments.</param>
        /// <returns>An <see cref="ApiResponse"/> containing DJ comments.</returns>
        Task<ApiResponse> GetDjComments(CommentRequestModel requestModel);

        /// <summary>
        /// Retrieves comments for a specific event.
        /// </summary>
        /// <param name="requestModel">The request model containing parameters for fetching event comments.</param>
        /// <returns>An <see cref="ApiResponse"/> containing event comments.</returns>
        Task<ApiResponse> GetEventComments(CommentRequestModel requestModel);

        /// <summary>
        /// Retrieves nested comments for a specific thread.
        /// </summary>
        /// <param name="requestModel">The request model containing parameters for fetching nested comments.</param>
        /// <returns>An <see cref="ApiResponse"/> containing nested comments.</returns>
        Task<ApiResponse> GetFloorComments(CommentFloorRequestModel requestModel);

        /// <summary>
        /// Retrieves hot comments for a specific resource.
        /// </summary>
        /// <param name="requestModel">The request model containing parameters for fetching hot comments.</param>
        /// <returns>An <see cref="ApiResponse"/> containing hot comments.</returns>
        Task<ApiResponse> GetHotComments(CommentHotRequestModel requestModel);

        /// <summary>
        /// Retrieves the list of users who liked a specific comment.
        /// </summary>
        /// <param name="requestModel">The request model containing parameters for fetching likes or hugs.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the list of likes or hugs.</returns>
        Task<ApiResponse> GetHugList(CommentHugListRequestModel requestModel);

        /// <summary>
        /// Likes or unlikes a specific comment.
        /// </summary>
        /// <param name="requestModel">The request model containing parameters for liking or unliking a comment.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> LikeComment(CommentLikeRequestModel requestModel);

        /// <summary>
        /// Retrieves comments for a specific music track.
        /// </summary>
        /// <param name="requestModel">The request model containing parameters for fetching music comments.</param>
        /// <returns>An <see cref="ApiResponse"/> containing music comments.</returns>
        Task<ApiResponse> GetMusicComments(CommentRequestModel requestModel);

        /// <summary>
        /// Retrieves comments for a specific music video (MV).
        /// </summary>
        /// <param name="requestModel">The request model containing parameters for fetching MV comments.</param>
        /// <returns>An <see cref="ApiResponse"/> containing MV comments.</returns>
        Task<ApiResponse> GetMvComments(CommentRequestModel requestModel);

        /// <summary>
        /// Retrieves new comments for a specific resource.
        /// </summary>
        /// <param name="requestModel">The request model containing parameters for fetching new comments.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the new comments.</returns>
        Task<ApiResponse> GetNewComments(CommentNewRequestModel requestModel);

        /// <summary>
        /// Retrieves comments for a specific playlist.
        /// </summary>
        /// <param name="requestModel">The request model containing parameters for fetching playlist comments.</param>
        /// <returns>An <see cref="ApiResponse"/> containing playlist comments.</returns>
        Task<ApiResponse> GetPlaylistComments(CommentRequestModel requestModel);

        /// <summary>
        /// Retrieves comments for a specific video.
        /// </summary>
        /// <param name="requestModel">The request model containing parameters for fetching video comments.</param>
        /// <returns>An <see cref="ApiResponse"/> containing video comments.</returns>
        Task<ApiResponse> GetVideoComments(CommentRequestModel requestModel);
    }
}
