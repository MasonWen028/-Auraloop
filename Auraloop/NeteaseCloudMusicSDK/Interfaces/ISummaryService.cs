using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for retrieving annual listening summaries in the Netease Cloud Music API.
    /// </summary>
    public interface ISummaryService
    {
        /// <summary>
        /// Retrieves the annual listening summary for a specific year.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for the annual summary query.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the annual listening summary.</returns>
        Task<ApiResponse> SummaryAnnual(SummaryAnnualRequestModel requestModel);
    }
}
