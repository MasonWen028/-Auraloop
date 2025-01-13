using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Request.yunbei;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing Yunbei-related operations in the Netease Cloud Music API.
    /// </summary>
    public interface IYunbeiService
    {
        /// <summary>
        /// Retrieves the current Yunbei points information for the user.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing Yunbei points information.</returns>
        Task<ApiResponse> GetPoints();

        /// <summary>
        /// Retrieves the Yunbei expense history.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the Yunbei expense history.</returns>
        Task<ApiResponse> ExpenseHistory(YunbeiExpenseRequestModel requestModel);

        /// <summary>
        /// Retrieves detailed Yunbei-related user information.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the user's Yunbei information.</returns>
        Task<ApiResponse> Info();

        /// <summary>
        /// Retrieves a list of Yunbei recommended songs for the user.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the recommended songs.</returns>
        Task<ApiResponse> RecommendedSongs(YunbeiRecommendedSongsRequestModel requestModel);

        /// <summary>
        /// Retrieves the history of Yunbei-recommended songs.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for pagination.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the recommended song history.</returns>
        Task<ApiResponse> RecommendedSongHistory(YunbeiRcmdSongHistoryRequestModel requestModel);

        /// <summary>
        /// Retrieves Yunbei receipt details for a specific transaction.
        /// </summary>
        /// <param name="requestModel">The unique identifier of the transaction.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the Yunbei receipt details.</returns>
        Task<ApiResponse> Receipt(YunbeiReceiptRequestModel requestModel);

        /// <summary>
        /// Signs in to claim daily Yunbei points.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the sign-in operation.</returns>
        Task<ApiResponse> DailySignin();

        /// <summary>
        /// Retrieves a list of Yunbei tasks available for the user.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the list of Yunbei tasks.</returns>
        Task<ApiResponse> Tasks();

        /// <summary>
        /// Retrieves a list of incomplete Yunbei tasks for the user.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the list of incomplete tasks.</returns>
        Task<ApiResponse> TodoTasks();

        /// <summary>
        /// Marks a Yunbei task as complete.
        /// </summary>
        /// <param name="taskId">The unique identifier of the task to mark as complete.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> CompleteTask(YunbeiTaskFinishRequestModel requestModel);

        /// <summary>
        /// Retrieves today's Yunbei activities and rewards.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing today's Yunbei activities and rewards.</returns>
        Task<ApiResponse> Today();
    }
}
