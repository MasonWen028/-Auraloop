using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing songs and related features in the Netease Cloud Music API.
    /// </summary>
    public interface ISongService
    {
        /// <summary>
        /// Retrieves the chorus times for a specific song.
        /// </summary>
        /// <param name="id">The unique identifier of the song.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the chorus times.</returns>
        Task<ApiResponse> Chorus(long id);

        /// <summary>
        /// Retrieves detailed information for multiple songs.
        /// </summary>
        /// <param name="requestModel">The model containing the song IDs.</param>
        /// <returns>An <see cref="ApiResponse"/> containing song details.</returns>
        Task<ApiResponse> Detail(SongDetailRequestModel requestModel);

        /// <summary>
        /// Retrieves the download list for members.
        /// </summary>
        /// <param name="requestModel">The model containing the pagination details.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the download list.</returns>
        Task<ApiResponse> Downlist(PaginatedRequestModel requestModel);

        /// <summary>
        /// Retrieves the download URL for a song.
        /// </summary>
        /// <param name="id">The unique identifier of the song.</param>
        /// <param name="bitrate">The desired bitrate for the download. Default is 999000.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the download URL.</returns>
        Task<ApiResponse> DownloadUrl(long id, int bitrate = 999000);

        /// <summary>
        /// Retrieves the download URL for a song with specified audio quality levels.
        /// </summary>
        /// <param name="id">The unique identifier of the song.</param>
        /// <param name="level">The audio quality level (e.g., standard, lossless, hires).</param>
        /// <returns>An <see cref="ApiResponse"/> containing the download URL.</returns>
        Task<ApiResponse> DownloadUrlV1(long id, string level = "h");

        /// <summary>
        /// Retrieves the dynamic cover for a specific song.
        /// </summary>
        /// <param name="id">The unique identifier of the song.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the dynamic cover information.</returns>
        Task<ApiResponse> DynamicCover(long id);

        /// <summary>
        /// Checks whether specific songs are liked by the user.
        /// </summary>
        /// <param name="ids">The IDs of the songs to check.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the like status of the songs.</returns>
        Task<ApiResponse> LikeCheck(long[] ids);

        /// <summary>
        /// Retrieves the member's download list for the current month.
        /// </summary>
        /// <param name="requestModel">The model containing the pagination details.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the download list.</returns>
        Task<ApiResponse> Monthdownlist(PaginatedRequestModel requestModel);

        /// <summary>
        /// Retrieves audio quality details for a specific song.
        /// </summary>
        /// <param name="id">The unique identifier of the song.</param>
        /// <returns>An <see cref="ApiResponse"/> containing audio quality details.</returns>
        Task<ApiResponse> MusicDetail(long id);

        /// <summary>
        /// Updates the order of songs in a playlist.
        /// </summary>
        /// <param name="requestModel">The model containing playlist and track details.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> OrderUpdate(SongOrderUpdateRequestModel requestModel);

        /// <summary>
        /// Retrieves the URLs for one or more songs, including specified bitrates.
        /// </summary>
        /// <param name="requestModel">The model containing the song IDs and bitrate.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the song URLs.</returns>
        Task<ApiResponse> Url(SongUrlRequestModel requestModel);

        /// <summary>
        /// Retrieves URLs for one or more songs, using audio quality levels.
        /// </summary>
        /// <param name="requestModel">The model containing song IDs and audio quality levels.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the song URLs with specified quality levels.</returns>
        Task<ApiResponse> UrlV1(SongUrlV1RequestModel requestModel);

        /// <summary>
        /// Retrieves basic wiki information for a specific song.
        /// </summary>
        /// <param name="id">The unique identifier of the song.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the song's wiki information.</returns>
        Task<ApiResponse> WikiSummary(long id);
    }
}
