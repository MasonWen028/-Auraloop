using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing cloud-related functionalities, including song uploads, imports, and matching in the Netease Cloud Music API.
    /// </summary>
    public interface ICloudService
    {
        /// <summary>
        /// Uploads a song to the user's cloud storage.
        /// </summary>
        /// <param name="requestModel">The request model containing details about the song to be uploaded.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the upload operation.</returns>
        Task<ApiResponse> UploadSong(SongUploadRequestModel requestModel);

        /// <summary>
        /// Imports songs or metadata into the user's cloud storage.
        /// </summary>
        /// <param name="requestModel">The request model containing details about the songs to import.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the import operation.</returns>
        Task<ApiResponse> ImportSongs(SongImportRequestModel requestModel);

        /// <summary>
        /// Matches a song in the user's cloud storage to the system's database.
        /// </summary>
        /// <param name="requestModel">The request model containing details for matching the song.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the results of the song match.</returns>
        Task<ApiResponse> MatchSong(SongMatchRequestModel requestModel);

        /// <summary>
        /// Searches for music-related content in the cloud database using specified keywords and filters.
        /// </summary>
        /// <param name="requestModel">The request model containing search parameters.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the search results.</returns>
        Task<ApiResponse> Search(CloudSearchRequestModel requestModel);
    }
}
