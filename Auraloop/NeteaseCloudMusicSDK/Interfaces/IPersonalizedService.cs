using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for retrieving personalized recommendations in the Netease Cloud Music API.
    /// </summary>
    public interface IPersonalizedService
    {
        /// <summary>
        /// Retrieves a list of personalized recommendations, such as playlists or content.
        /// </summary>
        /// <param name="limit">The maximum number of recommendations to retrieve. Default is 30.</param>
        /// <param name="total">Specifies whether to include the total count in the response. Default is true.</param>
        /// <param name="n">An optional parameter for advanced customization. Default is 1000.</param>
        /// <returns>An <see cref="ApiResponse"/> containing personalized recommendations.</returns>
        Task<ApiResponse> Personalized(int limit = 30, bool total = true, int n = 1000);

        /// <summary>
        /// Retrieves personalized recommendations for DJ programs.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing personalized DJ program recommendations.</returns>
        Task<ApiResponse> PersonalizedDjprogram();

        /// <summary>
        /// Retrieves personalized recommendations for music videos (MVs).
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing personalized MV recommendations.</returns>
        Task<ApiResponse> PersonalizedMv();

        /// <summary>
        /// Retrieves personalized recommendations for new songs.
        /// </summary>
        /// <param name="limit">The maximum number of new songs to retrieve. Default is 10.</param>
        /// <param name="areaId">The area or region ID for filtering new songs. Default is 0 (no filter).</param>
        /// <returns>An <see cref="ApiResponse"/> containing personalized new song recommendations.</returns>
        Task<ApiResponse> PersonalizedNewsong(int limit = 10, int areaId = 0);

        /// <summary>
        /// Retrieves personalized private content recommendations.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing personalized private content recommendations.</returns>
        Task<ApiResponse> PersonalizedPrivatecontent();

        /// <summary>
        /// Retrieves a list of personalized private content with pagination.
        /// </summary>
        /// <param name="limit">The maximum number of private content items to retrieve. Default is 60.</param>
        /// <param name="offset">The offset for pagination. Default is 0.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the list of personalized private content.</returns>
        Task<ApiResponse> PersonalizedPrivatecontentList(int limit = 60, int offset = 0);

        /// <summary>
        /// Retrieves the user's Personal FM recommendations, which are curated based on listening habits.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing Personal FM recommendations.</returns>
        Task<ApiResponse> PersonalFm();

        /// <summary>
        /// Toggles the mode of Personal FM, such as switching between different listening modes.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the mode change.</returns>
        Task<ApiResponse> PersonalFmMode();
    }
}
