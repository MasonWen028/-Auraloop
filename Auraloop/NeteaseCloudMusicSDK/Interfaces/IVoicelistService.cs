using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing voice lists and related data in the Netease Cloud Music API.
    /// </summary>
    public interface IVoiceService
    {
        /// <summary>
        /// Retrieves detailed information about a specific voice list.
        /// </summary>
        /// <param name="id">The unique identifier of the voice list.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the voice list details.</returns>
        Task<ApiResponse> ListDetail(long id);

        /// <summary>
        /// Retrieves a list of voices in a specific voice list with pagination.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching voices by voice list.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the list of voices.</returns>
        Task<ApiResponse> List(VoiceListRequestModel requestModel);

        /// <summary>
        /// Searches for voices within a specific voice list.
        /// </summary>
        /// <param name="requestModel">The model containing search parameters for voices.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the search results.</returns>
        Task<ApiResponse> ListSearch(VoiceListSearchRequestModel requestModel);

        /// <summary>
        /// Searches for voice lists by podcast name.
        /// </summary>
        /// <param name="requestModel">The model containing search parameters for voice lists.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the search results.</returns>
        Task<ApiResponse> Search(VoiceListSearchRequestModel requestModel);

        /// <summary>
        /// Transfers a program between voice lists.
        /// </summary>
        /// <param name="requestModel">The model containing transfer parameters.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the transfer operation.</returns>
        Task<ApiResponse> Trans(VoicelistTransRequestModel requestModel);

        /// <summary>
        /// Deletes one or more voices.
        /// </summary>
        /// <param name="ids">An array of IDs of the voices to delete.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the deletion operation.</returns>
        Task<ApiResponse> Delete(long[] ids);

        /// <summary>
        /// Retrieves detailed information about a specific voice.
        /// </summary>
        /// <param name="id">The unique identifier of the voice.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the voice details.</returns>
        Task<ApiResponse> Detail(long id);

        /// <summary>
        /// Retrieves the lyrics associated with a specific voice program.
        /// </summary>
        /// <param name="programId">The unique identifier of the voice program.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the lyrics of the voice program.</returns>
        Task<ApiResponse> Lyric(long programId);

        /// <summary>
        /// Uploads a voice to the platform.
        /// </summary>
        /// <param name="requestModel">The model containing the voice upload details.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the upload operation.</returns>
        Task<ApiResponse> Upload(VoiceUploadRequestModel requestModel);
    }
}
