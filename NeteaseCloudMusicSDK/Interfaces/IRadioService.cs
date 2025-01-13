using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing radio-related features in the Netease Cloud Music API.
    /// </summary>
    public interface IRadioService
    {
        /// <summary>
        /// Retrieves the banner information for radio programs.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the radio banner details.</returns>
        Task<ApiResponse> Banner();

        /// <summary>
        /// Retrieves radio categories excluding the most popular ones.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing non-popular radio categories.</returns>
        Task<ApiResponse> CategoryExcludeHot();

        /// <summary>
        /// Retrieves recommended radio categories.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing recommended radio categories.</returns>
        Task<ApiResponse> CategoryRecommend();

        /// <summary>
        /// Retrieves the list of all radio categories.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing all radio categories.</returns>
        Task<ApiResponse> CategoryList();

        /// <summary>
        /// Retrieves detailed information about a specific radio station.
        /// </summary>
        /// <param name="rid">The unique identifier of the radio station.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the radio station details.</returns>
        Task<ApiResponse> Detail(long rid);

        /// <summary>
        /// Retrieves a list of the most popular radio programs with pagination.
        /// </summary>
        /// <param name="requestModel">The model containing pagination parameters.</param>
        /// <returns>An <see cref="ApiResponse"/> containing popular radio programs.</returns>
        Task<ApiResponse> Hot(RadioHotRequestModel requestModel);

        /// <summary>
        /// Retrieves information about paid radio gift programs with pagination.
        /// </summary>
        /// <param name="requestModel">The model containing pagination parameters.</param>
        /// <returns>An <see cref="ApiResponse"/> containing paid radio gift programs.</returns>
        Task<ApiResponse> PayGift(RadioPayGiftRequestModel requestModel);

        /// <summary>
        /// Retrieves personalized recommendations for radio programs.
        /// </summary>
        /// <param name="limit">The maximum number of recommended results. Default is 6.</param>
        /// <returns>An <see cref="ApiResponse"/> containing personalized recommendations.</returns>
        Task<ApiResponse> PersonalizedRecommend(int limit = 6);

        /// <summary>
        /// Retrieves programs of a specific radio station with pagination.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching programs.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the radio station programs.</returns>
        Task<ApiResponse> Programs(RadioProgramsRequestModel requestModel);

        /// <summary>
        /// Retrieves detailed information about a specific radio program.
        /// </summary>
        /// <param name="id">The unique identifier of the radio program.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the program details.</returns>
        Task<ApiResponse> ProgramDetail(long id);

        /// <summary>
        /// Retrieves the top-ranked radio programs.
        /// </summary>
        /// <param name="requestModel">The model containing pagination parameters for the toplist.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the top-ranked radio programs.</returns>
        Task<ApiResponse> ProgramToplist(RadioProgramToplistRequestModel requestModel);

        /// <summary>
        /// Retrieves the top-ranked radio programs for the last 24 hours.
        /// </summary>
        /// <param name="limit">The maximum number of results to retrieve. Default is 100.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the hourly top-ranked radio programs.</returns>
        Task<ApiResponse> ProgramToplistByHour(int limit = 100);

        /// <summary>
        /// Retrieves popular radio stations in a specific category with pagination.
        /// </summary>
        /// <param name="requestModel">The model containing category and pagination parameters.</param>
        /// <returns>An <see cref="ApiResponse"/> containing popular radio stations.</returns>
        Task<ApiResponse> HotStations(RadioHotStationsRequestModel requestModel);

        /// <summary>
        /// Retrieves recommended radio stations.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing recommended radio stations.</returns>
        Task<ApiResponse> Recommend();

        /// <summary>
        /// Retrieves recommended radio stations based on a specific category.
        /// </summary>
        /// <param name="cateId">The category identifier for the recommendations.</param>
        /// <returns>An <see cref="ApiResponse"/> containing category-specific recommendations.</returns>
        Task<ApiResponse> RecommendByType(long cateId);

        /// <summary>
        /// Subscribes or unsubscribes to a radio station.
        /// </summary>
        /// <param name="requestModel">The model containing subscription parameters.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the subscription operation.</returns>
        Task<ApiResponse> Subscription(RadioSubscriptionRequestModel requestModel);

        /// <summary>
        /// Retrieves the list of subscribed radio stations with pagination.
        /// </summary>
        /// <param name="requestModel">The model containing pagination parameters.</param>
        /// <returns>An <see cref="ApiResponse"/> containing subscribed radio stations.</returns>
        Task<ApiResponse> Subscriptions(RadioSubscriptionsRequestModel requestModel);

        /// <summary>
        /// Retrieves the list of subscribers to a specific radio station.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for subscriber retrieval.</param>
        /// <returns>An <see cref="ApiResponse"/> containing subscribers of the radio station.</returns>
        Task<ApiResponse> Subscribers(RadioSubscribersRequestModel requestModel);

        /// <summary>
        /// Retrieves today's preferred radio programs.
        /// </summary>
        /// <param name="page">The page number for today's preferred programs. Default is 0.</param>
        /// <returns>An <see cref="ApiResponse"/> containing today's preferred programs.</returns>
        Task<ApiResponse> TodayPreferred(int page = 0);

        /// <summary>
        /// Retrieves the top-ranked radio stations based on type.
        /// </summary>
        /// <param name="requestModel">The model containing list type and pagination parameters.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the top-ranked radio stations.</returns>
        Task<ApiResponse> Toplist(RadioToplistRequestModel requestModel);

        /// <summary>
        /// Prevents a specific FM song from being played again by moving it to the trash.
        /// </summary>
        /// <param name="requestModel">The model containing the song ID and played time.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> TrashSong(RadioTrashSongRequestModel requestModel);

        /// <summary>
        /// Likes or unlikes a song in the radio.
        /// </summary>
        /// <param name="requestModel">The model containing the song ID and like action.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the like action.</returns>
        Task<ApiResponse> Like(RadioLikeRequestModel requestModel);

        /// <summary>
        /// Retrieves the rankings for a specific radio station based on various metrics.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching radio rankings.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the radio rankings.</returns>
        Task<ApiResponse> GetRadioRankings(RadioRankingRequestModel requestModel);
    }
}
