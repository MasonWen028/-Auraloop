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
        /// Retrieves comments for a generic entity.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the comments for the entity.</returns>
        Task<ApiResponse> Comment();

        /// <summary>
        /// Retrieves comments for a specific album.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing album comments.</returns>
        Task<ApiResponse> CommentAlbum();

        /// <summary>
        /// Retrieves comments for a specific DJ program.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing DJ program comments.</returns>
        Task<ApiResponse> CommentDj();

        /// <summary>
        /// Retrieves comments for a specific event.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing event comments.</returns>
        Task<ApiResponse> CommentEvent();

        /// <summary>
        /// Retrieves comments for a specific floor (nested comment level).
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing floor comments.</returns>
        Task<ApiResponse> CommentFloor();

        /// <summary>
        /// Retrieves hot (popular) comments based on the provided request model.
        /// </summary>
        /// <param name="requestModel">The request model containing parameters for retrieving hot comments.</param>
        /// <returns>An <see cref="ApiResponse"/> containing hot comments.</returns>
        Task<ApiResponse> CommentHot(CommentHotRequestModel requestModel);

        /// <summary>
        /// Retrieves the list of comment likes or "hugs."
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the list of likes or hugs.</returns>
        Task<ApiResponse> CommentHugList();

        /// <summary>
        /// Likes or unlikes a specific comment based on the provided request model.
        /// </summary>
        /// <param name="requestModel">The request model containing parameters for liking or unliking a comment.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> CommentLike(CommentLikeRequestModel requestModel);

        /// <summary>
        /// Retrieves comments for a specific music track.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing music comments.</returns>
        Task<ApiResponse> CommentMusic();

        /// <summary>
        /// Retrieves comments for a specific music video (MV).
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing MV comments.</returns>
        Task<ApiResponse> CommentMv();

        /// <summary>
        /// Retrieves new comments based on the provided request model.
        /// </summary>
        /// <param name="requestModel">The request model containing parameters for retrieving new comments.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the newest comments.</returns>
        Task<ApiResponse> CommentNew(CommentNewRequestModel requestModel);

        /// <summary>
        /// Retrieves comments for a specific playlist.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing playlist comments.</returns>
        Task<ApiResponse> CommentPlaylist();

        /// <summary>
        /// Retrieves comments for a specific video.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing video comments.</returns>
        Task<ApiResponse> CommentVideo();

        /// <summary>
        /// Adds a "hug" (positive interaction) to a specific comment.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the hug action.</returns>
        Task<ApiResponse> HugComment();

        /// <summary>
        /// Retrieves a summary of comments from the Starpick comments section.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for retrieving the comments summary.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the summary of comments.</returns>
        Task<ApiResponse> StarpickCommentsSummary(StarpickCommentsSummaryRequestModel requestModel);
    }

}