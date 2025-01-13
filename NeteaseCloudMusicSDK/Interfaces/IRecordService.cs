using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for retrieving records of recently accessed content in the Netease Cloud Music API.
    /// </summary>
    public interface IRecordService
    {
        /// <summary>
        /// Retrieves a list of recently accessed albums.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the recent album history.</returns>
        Task<ApiResponse> RecentAlbum(int limit);

        /// <summary>
        /// Retrieves a list of recently accessed radio programs.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the recent radio history.</returns>
        Task<ApiResponse> RecentRadio(int limit);

        /// <summary>
        /// Retrieves a list of recently accessed playlists.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the recent playlist history.</returns>
        Task<ApiResponse> RecentPlaylist(int limit);

        /// <summary>
        /// Retrieves a list of recently accessed songs.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the recent song history.</returns>
        Task<ApiResponse> RecentSong(int limit);

        /// <summary>
        /// Retrieves a list of recently accessed videos.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the recent video history.</returns>
        Task<ApiResponse> RecentVideo(int limit);

        /// <summary>
        /// Retrieves a list of recently accessed voice recordings or audio content.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the recent voice history.</returns>
        Task<ApiResponse> RecentVoice(int limit);

        /// <summary>
        /// Retrieves the list of recently listened-to songs or other audio content for the user.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the recent listening history.</returns>
        Task<ApiResponse> RecentListenList();
    }
}
