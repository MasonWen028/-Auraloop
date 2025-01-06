using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for retrieving style-related data such as albums, artists, playlists, and songs in the Netease Cloud Music API.
    /// </summary>
    public interface IStyleService
    {
        /// <summary>
        /// Retrieves a list of albums related to a specific style.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching style albums.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the style-related albums.</returns>
        Task<ApiResponse> Album(StyleRequestModel requestModel);

        /// <summary>
        /// Retrieves a list of artists related to a specific style.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching style artists.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the style-related artists.</returns>
        Task<ApiResponse> Artist(StyleRequestModel requestModel);

        /// <summary>
        /// Retrieves detailed information about a specific style.
        /// </summary>
        /// <param name="tagId">The unique identifier for the style tag.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the style details.</returns>
        Task<ApiResponse> Detail(long tagId);

        /// <summary>
        /// Retrieves a list of all available styles.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the list of styles.</returns>
        Task<ApiResponse> List();

        /// <summary>
        /// Retrieves a list of playlists related to a specific style.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching style playlists.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the style-related playlists.</returns>
        Task<ApiResponse> Playlist(StyleRequestModel requestModel);

        /// <summary>
        /// Retrieves the user's style preferences.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the user's style preferences.</returns>
        Task<ApiResponse> Preference();

        /// <summary>
        /// Retrieves a list of songs related to a specific style.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching style songs.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the style-related songs.</returns>
        Task<ApiResponse> Song(StyleRequestModel requestModel);
    }
}
