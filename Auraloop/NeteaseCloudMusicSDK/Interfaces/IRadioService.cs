using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for interacting with radio-related features in the Netease Cloud Music API.
    /// </summary>
    public interface IRadioService
    {
        /// <summary>
        /// Retrieves the banner information for radio programs.
        /// </summary>
        Task<ApiResponse> RadioBanner();

        /// <summary>
        /// Retrieves radio categories excluding the most popular ones.
        /// </summary>
        Task<ApiResponse> RadioCategoryExcludeHot();

        /// <summary>
        /// Retrieves recommended radio categories.
        /// </summary>
        Task<ApiResponse> RadioCategoryRecommend();

        /// <summary>
        /// Retrieves the list of all radio categories.
        /// </summary>
        Task<ApiResponse> RadioCategoryList();

        /// <summary>
        /// Retrieves detailed information about a specific radio station.
        /// </summary>
        /// <param name="rid">The unique identifier of the radio station.</param>
        Task<ApiResponse> RadioDetail(long rid);

        /// <summary>
        /// Retrieves a list of the most popular radio programs.
        /// </summary>
        Task<ApiResponse> RadioHot();

        /// <summary>
        /// Retrieves information about paid radio gift programs.
        /// </summary>
        Task<ApiResponse> RadioPayGift();

        /// <summary>
        /// Retrieves personalized recommendations for radio programs.
        /// </summary>
        Task<ApiResponse> RadioPersonalizedRecommend();

        /// <summary>
        /// Retrieves programs of a specific radio station with pagination.
        /// </summary>
        /// <param name="rid">The unique identifier of the radio station.</param>
        /// <param name="limit">The maximum number of results to retrieve. Default is 50.</param>
        /// <param name="offset">The offset for pagination. Default is 0.</param>
        /// <param name="asc">Whether to sort the results in ascending order. Default is false.</param>
        Task<ApiResponse> RadioPrograms(long rid, int limit = 50, int offset = 0, bool asc = false);

        /// <summary>
        /// Retrieves detailed information about a specific radio program.
        /// </summary>
        /// <param name="id">The unique identifier of the radio program.</param>
        Task<ApiResponse> RadioProgramDetail(long id);

        /// <summary>
        /// Retrieves the top-ranked radio programs.
        /// </summary>
        Task<ApiResponse> RadioProgramToplist();

        /// <summary>
        /// Retrieves the top-ranked radio programs for the current hour.
        /// </summary>
        Task<ApiResponse> RadioProgramToplistByHour();

        /// <summary>
        /// Retrieves popular radio stations in a specific category with pagination.
        /// </summary>
        /// <param name="cateId">The category identifier for the radio stations.</param>
        /// <param name="limit">The maximum number of results to retrieve. Default is 50.</param>
        /// <param name="offset">The offset for pagination. Default is 0.</param>
        Task<ApiResponse> RadioHotStations(long cateId, int limit = 50, int offset = 0);

        /// <summary>
        /// Retrieves recommended radio stations.
        /// </summary>
        Task<ApiResponse> RadioRecommend();

        /// <summary>
        /// Retrieves recommended radio stations based on a specific category.
        /// </summary>
        /// <param name="cateId">The category identifier for the recommendations.</param>
        Task<ApiResponse> RadioRecommendByType(long cateId);

        /// <summary>
        /// Subscribes or unsubscribes to a radio station.
        /// </summary>
        /// <param name="rid">The unique identifier of the radio station.</param>
        /// <param name="subOpType">The operation type (subscribe or unsubscribe).</param>
        Task<ApiResponse> RadioSubscription(long rid, SubOpType subOpType = SubOpType.subscribe);

        /// <summary>
        /// Retrieves the list of subscribed radio stations with pagination.
        /// </summary>
        /// <param name="limit">The maximum number of results to retrieve. Default is 50.</param>
        /// <param name="offset">The offset for pagination. Default is 0.</param>
        Task<ApiResponse> RadioSubscriptions(int limit = 50, int offset = 0);

        /// <summary>
        /// Retrieves the list of subscribers to a specific radio station.
        /// </summary>
        Task<ApiResponse> RadioSubscribers();

        /// <summary>
        /// Retrieves today's preferred radio programs.
        /// </summary>
        Task<ApiResponse> RadioTodayPreferred();

        /// <summary>
        /// Retrieves the top-ranked radio programs in a specific list type.
        /// </summary>
        /// <param name="listType">The type of list for ranking.</param>
        /// <param name="limit">The maximum number of results to retrieve. Default is 20.</param>
        /// <param name="offset">The offset for pagination. Default is 0.</param>
        Task<ApiResponse> RadioToplist(ListType listType, int limit = 20, int offset = 0);

        /// <summary>
        /// Retrieves the top-ranked radio programs by newcomers.
        /// </summary>
        Task<ApiResponse> RadioToplistNewcomer();

        /// <summary>
        /// Retrieves the top-ranked paid radio programs.
        /// </summary>
        Task<ApiResponse> RadioToplistPaid();

        /// <summary>
        /// Retrieves the most popular radio programs.
        /// </summary>
        Task<ApiResponse> RadioToplistPopular();

        /// <summary>
        /// Retrieves AI-driven recommendations for radio content based on the provided request model.
        /// </summary>
        /// <param name="requestModel">The request model containing context and preferences for recommendations.</param>
        Task<ApiResponse> RadioAIRecommendations(ExtInfo requestModel);

        /// <summary>
        /// Retrieves the top radio stations.
        /// </summary>
        Task<ApiResponse> RadioTopStations();

        /// <summary>
        /// Throws an FM song into the trash bin, preventing it from playing again.
        /// </summary>
        /// <param name="id">The unique identifier of the FM song.</param>
        /// <param name="time">The duration (in seconds) for which the song was played. Default is 25 seconds.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> RadioTrashSong(long id, long time = 25);

        /// <summary>
        /// Likes or unlikes a song in the radio.
        /// </summary>
        /// <param name="id">The unique identifier of the song.</param>
        /// <param name="like">A boolean value indicating whether to like (true) or unlike (false) the song.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the like action.</returns>
        Task<ApiResponse> Like(long id, bool like);

    }
}
