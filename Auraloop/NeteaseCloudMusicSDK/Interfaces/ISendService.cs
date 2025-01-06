using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for sending private messages, such as albums, playlists, songs, or text, in the Netease Cloud Music API.
    /// </summary>
    public interface ISendService
    {
        /// <summary>
        /// Sends an album as a private message.
        /// </summary>
        /// <param name="requestModel">The model containing the album details and recipients.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> SendAlbum(SendAlbumRequestModel requestModel);

        /// <summary>
        /// Sends a playlist as a private message.
        /// </summary>
        /// <param name="requestModel">The model containing the playlist details and recipients.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> SendPlaylist(SendPlaylistRequestModel requestModel);

        /// <summary>
        /// Sends a song as a private message.
        /// </summary>
        /// <param name="requestModel">The model containing the song details and recipients.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> SendSong(SendSongRequestModel requestModel);

        /// <summary>
        /// Sends a text message as a private message.
        /// </summary>
        /// <param name="requestModel">The model containing the text message and recipients.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> SendText(SendTextRequestModel requestModel);
    }
}
