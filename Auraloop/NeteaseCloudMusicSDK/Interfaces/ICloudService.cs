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
        Task<ApiResponse> Cloud(SongUploadRequestModel requestModel);

        /// <summary>
        /// Imports songs or metadata into the user's cloud storage.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the import operation.</returns>
        Task<ApiResponse> CloudImport();

        /// <summary>
        /// Matches a song in the user's cloud storage to the system's database.
        /// </summary>
        /// <param name="uid">The unique identifier of the user.</param>
        /// <param name="sid">The song identifier in the user's cloud storage.</param>
        /// <param name="asid">An additional song identifier for matching purposes.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the results of the song match.</returns>
        Task<ApiResponse> CloudMatch(long uid, long sid, long asid);

        /// <summary>
        /// Searches for music-related content in the cloud database using specified keywords and filters.
        /// </summary>
        /// <param name="keywords">The search query or keywords to find relevant content.</param>
        /// <param name="limit">The maximum number of results to retrieve. Default is 50.</param>
        /// <param name="offset">The offset for pagination. Default is 0.</param>
        /// <param name="type">The type of content to search for (e.g., songs, albums, artists). Default is <see cref="SearchTypes.All"/>.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the search results.</returns>
        Task<ApiResponse> Cloudsearch(string keywords, int limit = 50, int offset = 0, SearchTypes type = SearchTypes.All);
    }
}
