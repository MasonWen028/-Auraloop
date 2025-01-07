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
        /// <param name="requestModel">The model containing parameters for fetching personalized recommendations.</param>
        /// <returns>An <see cref="ApiResponse"/> containing personalized recommendations.</returns>
        Task<ApiResponse> GetRecommendations(PersonalizedRequestModel requestModel);

        /// <summary>
        /// Retrieves personalized recommendations for DJ programs.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing personalized DJ program recommendations.</returns>
        Task<ApiResponse> Djprogram();

        /// <summary>
        /// Retrieves personalized recommendations for music videos (MVs).
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing personalized MV recommendations.</returns>
        Task<ApiResponse> Mv();

        /// <summary>
        /// Retrieves personalized recommendations for new songs.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching personalized new songs.</param>
        /// <returns>An <see cref="ApiResponse"/> containing personalized new song recommendations.</returns>
        Task<ApiResponse> Newsong(PersonalizedNewsongRequestModel requestModel);

        /// <summary>
        /// Retrieves personalized private content recommendations.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing personalized private content recommendations.</returns>
        Task<ApiResponse> Privatecontent();

        /// <summary>
        /// Retrieves a list of personalized private content with pagination.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching personalized private content.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the list of personalized private content.</returns>
        Task<ApiResponse> PrivatecontentList(PersonalizedPrivatecontentListRequestModel requestModel);

        /// <summary>
        /// Retrieves the user's Personal FM recommendations, which are curated based on listening habits.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing Personal FM recommendations.</returns>
        Task<ApiResponse> PersonalFm();

        /// <summary>
        /// Toggles the mode of Personal FM, such as switching between different listening modes.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for changing the Personal FM mode.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the mode change.</returns>
        Task<ApiResponse> PersonalFmMode(PersonalFmModeRequestModel requestModel);
    }
}
