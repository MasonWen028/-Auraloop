using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing play modes and related features in the Netease Cloud Music API.
    /// </summary>
    public interface IPlaymodeService
    {
        /// <summary>
        /// Retrieves an intelligent list of songs for a specific play mode.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for generating the intelligent list.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the intelligently generated list of songs.</returns>
        Task<ApiResponse> IntelligenceList(PlaymodeIntelligenceListRequestModel requestModel);

        /// <summary>
        /// Retrieves song vectors for play mode analysis and personalization.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for retrieving song vectors.</param>
        /// <returns>An <see cref="ApiResponse"/> containing song vector data, which can be used for advanced play mode personalization.</returns>
        Task<ApiResponse> SongVector(PlaymodeSongVectorRequestModel requestModel);
    }
}
