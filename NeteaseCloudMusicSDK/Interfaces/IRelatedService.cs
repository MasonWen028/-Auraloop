using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for retrieving related content, such as videos and playlists, in the Netease Cloud Music API.
    /// </summary>
    public interface IRelatedService
    {
        /// <summary>
        /// Retrieves a list of videos related to a specific context, such as a song or artist.
        /// </summary>
        /// <param name="id">
        /// RelatedAllvideoRequestModel model = new RelatedAllvideoRequestModel(id)
        /// </param>
        /// <returns></returns>
        Task<ApiResponse> AllVideo(string id);

                
        /// <summary>
        /// Retrieves playlists related to a specific context, such as a song or artist.
        /// </summary>
        /// <param name="id">
        /// curl -X GET "https://music.163.com/playlist?id={id}"
        /// </param>
        /// <returns></returns>
        Task<ApiResponse> Playlist(string id);
    }
}
