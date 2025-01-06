using System;
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
        /// <param name="id">The unique identifier of the song being used as a reference for recommendations.</param>
        /// <param name="pid">The playlist ID for context in generating recommendations.</param>
        /// <param name="sid">An optional parameter for specifying a seed song ID for more targeted recommendations.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the intelligently generated list of songs.</returns>
        Task<ApiResponse> PlaymodeIntelligenceList(long id, long pid, long? sid);

        /// <summary>
        /// Retrieves song vectors for play mode analysis and personalization.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing song vector data, which can be used for advanced play mode personalization.</returns>
        Task<ApiResponse> PlaymodeSongVector();
    }
}
